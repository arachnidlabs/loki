using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using CyUSB;
using System.IO;

namespace LokiProgrammer
{
    public class FreebooterHost
    {        
        public delegate void ProgressUpdate(int percent, byte arrayID, ushort rowNum);

        public event ProgressUpdate Progress;
        protected CommunicationsChannel _channel;
        protected PacketChecksumType _checksumType;
        protected bool _abort;
        protected FirmwareReader reader = null;
        private GetFlashSizeResponse[] flashRanges;

        protected uint siliconId;
        protected uint siliconRev;
        protected uint bootloaderVersion;

        const UInt32 SUPPORTED_BOOTLOADER = 0x010000;
        const UInt32 BOOTLOADER_VERSION_MASK = 0xFF0000;
        private const int MAX_FLASH_ARRAYS = 4;

        public enum Actions
        {
            PROGRAM,
            VERIFY,
            ERASE
        }

        public FreebooterHost(CommunicationsChannel channel)
        {
            _channel = channel;
        }

        public PacketChecksumType ChecksumType
        {
            get
            {
                return _checksumType;
            }
            set
            {
                _checksumType = value;
            }
        }

        public void Program(String file)
        {
            Program(new System.IO.FileStream(file, FileMode.Open));
        }

        public void DoAction(Actions action, Stream file) {
            _abort = false;

            reader = new FirmwareReader(file);
            flashRanges = new GetFlashSizeResponse[MAX_FLASH_ARRAYS];

            try
            {
                EnterBootloaderResponse blInfo = this.EnterBootloader();
                if (blInfo.SiliconId != reader.SiliconId || blInfo.SiliconRev != reader.SiliconRev)
                    throw new UnsupportedDeviceException(blInfo.SiliconId, blInfo.SiliconRev, reader.SiliconId, reader.SiliconRev);
                if ((blInfo.Version & BOOTLOADER_VERSION_MASK) != SUPPORTED_BOOTLOADER)
                    throw new UnsupportedBootloaderException(blInfo.Version);

                for (FirmwareReader.Row row = reader.ReadRow(); row != null; row = reader.ReadRow())
                {
                    if (_abort) break;

                    ValidateRow(row.ArrayId, row.RowNumber);

                    switch (action)
                    {
                        case Actions.PROGRAM:
                            this.ProgramRow(row.ArrayId, row.RowNumber, row.Data);
                            goto case Actions.VERIFY;
                        case Actions.VERIFY:
                            byte checksum2 = (byte)(row.Checksum + row.ArrayId + row.RowNumber + (row.RowNumber >> 8) + row.Data.Length + (row.Data.Length >> 8));
                            VerifyRowResponse verify = this.VerifyRow(row.ArrayId, row.RowNumber);
                            if (verify.Checksum != checksum2)
                                throw new InvalidChecksumException(row.ArrayId, row.RowNumber);
                            break;
                        case Actions.ERASE:
                            this.EraseRow(row.ArrayId, row.RowNumber);
                            break;
                    }
                    if (this.Progress != null)
                        this.Progress((int)((reader.Position * 100) / reader.Length), row.ArrayId, row.RowNumber);
                }

                if (action != Actions.ERASE)
                {
                    VerifyChecksumResponse appVerify = this.VerifyChecksum();
                    if (!appVerify.ChecksumValid)
                        throw new InvalidChecksumException();
                }
            }
            finally
            {
                reader.Close();
                reader = null;
            }
        }

        private void ValidateRow(byte arrayId, ushort rowNumber)
        {
            if (arrayId >= MAX_FLASH_ARRAYS)
                throw new InvalidRowException();

            GetFlashSizeResponse range = flashRanges[arrayId];
            if(range == null) {
                range = flashRanges[arrayId] = this.GetFlashSize(arrayId);
            }

            if (rowNumber < range.FirstRow || rowNumber > range.LastRow)
                throw new InvalidRowException();
        }

        public void Program(Stream file)
        {
            DoAction(Actions.PROGRAM, file);
        }

        public void Erase(Stream file)
        {
            DoAction(Actions.ERASE, file);
        }

        public void Verify(Stream file)
        {
            DoAction(Actions.VERIFY, file);
        }

        public void Abort()
        {
            _abort = true;
        }

        protected void SendCommand(BootloaderCommand command, BootloaderResponse response)
        {
            byte[] requestData = command.Serialize();
            _channel.WriteData(requestData, requestData.Length);
            
            byte[] responseData = new byte[_channel.MaxTransferSize];
            _channel.ReadData(responseData, responseData.Length);
            response.Deserialize(_checksumType, responseData);
        }

        public EnterBootloaderResponse EnterBootloader()
        {
            EnterBootloaderCommand cmd = new EnterBootloaderCommand(_checksumType);
            EnterBootloaderResponse response = new EnterBootloaderResponse();
            SendCommand(cmd, response);

            this.siliconId = response.SiliconId;
            this.siliconRev = response.SiliconRev;
            this.bootloaderVersion = response.Version;
            return response;
        }

        public GetFlashSizeResponse GetFlashSize(int flashArrayId)
        {
            GetFlashSizeCommand cmd = new GetFlashSizeCommand(_checksumType, (byte)flashArrayId);
            GetFlashSizeResponse response = new GetFlashSizeResponse();
            SendCommand(cmd, response);
            return response;
        }

        public void ProgramRow(int flashArrayId, int rowNumber, byte[] data)
        {
            int i;
            int maxChunkSize = (int)_channel.MaxTransferSize - 11;
            byte[] chunk = new byte[maxChunkSize];
            EmptyResponse response = new EmptyResponse();

            // Break the data transfer up into pieces that aren't too large
            for (i = 0; i < data.Length - maxChunkSize; i += maxChunkSize)
            {
                Array.Copy(data, i, chunk, 0, maxChunkSize);
                SendDataCommand sd = new SendDataCommand(_checksumType, chunk);
                SendCommand(sd, response);
            }

            // Send the last chunk and the program command
            chunk = new byte[data.Length - i];
            Array.Copy(data, i, chunk, 0, data.Length - i);
            ProgramRowCommand cmd = new ProgramRowCommand(_checksumType, (byte)flashArrayId, (ushort)rowNumber, chunk);
            SendCommand(cmd, response);
        }

        public void EraseRow(int flashArrayId, int rowNumber)
        {
            EraseRowCommand cmd = new EraseRowCommand(_checksumType, (byte)flashArrayId, (ushort)rowNumber);
            EmptyResponse response = new EmptyResponse();
            SendCommand(cmd, response);
        }

        public VerifyRowResponse VerifyRow(int flashArrayId, int rowNumber)
        {
            VerifyRowCommand cmd = new VerifyRowCommand(_checksumType, (byte)flashArrayId, (ushort)rowNumber);
            VerifyRowResponse response = new VerifyRowResponse();
            SendCommand(cmd, response);
            return response;
        }

        public VerifyChecksumResponse VerifyChecksum()
        {
            VerifyChecksumCommand cmd = new VerifyChecksumCommand(_checksumType);
            VerifyChecksumResponse response = new VerifyChecksumResponse();
            SendCommand(cmd, response);
            return response;
        }

        protected void SendData(byte[] data)
        {
            SendDataCommand cmd = new SendDataCommand(_checksumType, data);
            EmptyResponse response = new EmptyResponse();
            SendCommand(cmd, response);
        }

        public void SyncBootloader()
        {
            SyncBootloaderCommand cmd = new SyncBootloaderCommand(_checksumType);
            EmptyResponse response = new EmptyResponse();
            SendCommand(cmd, response);
        }

        public void ExitBootloader()
        {
            ExitBootloaderCommand cmd = new ExitBootloaderCommand(_checksumType);
            byte[] requestData = cmd.Serialize();
            _channel.WriteData(requestData, requestData.Length);
        }

        public uint SiliconId
        {
            get
            {
                return this.siliconId;
            }
        }

        public uint SiliconRev
        {
            get
            {
                return this.siliconRev;
            }
        }

        public uint BootloaderVersion
        {
            get
            {
                return this.bootloaderVersion;
            }
        }
    }
}
