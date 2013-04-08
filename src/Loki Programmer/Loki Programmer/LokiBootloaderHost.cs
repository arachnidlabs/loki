using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    class I2CTransferCommand : BootloaderCommand
    {
        private byte slaveAddress;
        private byte[] writeData;
        private byte writeLen;
        private byte readLen;

        public I2CTransferCommand(PacketChecksumType checksumType, byte slaveAddress, byte[] writeData, byte writeLen, byte readLen)
            : base(checksumType)
        {
            this.slaveAddress = slaveAddress;
            this.writeData = writeData;
            this.writeLen = writeLen;
            this.readLen = readLen;
        }

        public override void SerializePayload(MiscUtil.IO.EndianBinaryWriter writer)
        {
            writer.Write(slaveAddress);
            writer.Write((byte) writeLen);
            writer.Write(readLen);
            writer.Write(writeData, 0, writeLen);
        }

        public override byte CommandCode
        {
            get { return 0x80; }
        }
    }

    public class I2CTransferResponse : BootloaderResponse
    {
        private byte[] data = null;

        public I2CTransferResponse() { }

        public override void DeserializePayload(MiscUtil.IO.EndianBinaryReader reader, ushort length)
        {
            byte data_len = reader.ReadByte();
            data = reader.ReadBytes(data_len);
        }

        public byte[] Data
        {
            get { return data; }
        }
    }

    public class LokiBootloaderHost : FreebooterHost
    {
        private const byte LOKI_EEPROM_ADDR = 0x50;
        private static byte[] PLANK_EEPROM_ADDRS = new byte[] { 0x51, 0x52, 0x55, 0x53, 0x57, 0x56, 0x54 };

        private class EEPROMStream : Stream
        {
            private const int PAGE_SIZE = 32;

            private LokiBootloaderHost host;
            private byte slaveAddress;
            private long length;
            private long position;
            private byte[] readBuf;
            private int readBufPosition;

            public EEPROMStream(LokiBootloaderHost host, byte slaveAddress, long length)
            {
                this.host = host;
                this.slaveAddress = slaveAddress;
                this.length = length;
                this.readBuf = new byte[PAGE_SIZE];
                this.readBufPosition = this.readBuf.Length;
            }

            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return true; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }

            public override void Flush()
            {
                throw new NotImplementedException();
            }

            public override long Length
            {
                get { return length; }
            }

            public override long Position
            {
                get
                {
                    return position;
                }
                set
                {
                    this.Seek(value, SeekOrigin.Begin);
                }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int countRemaining = count;
                while (countRemaining > 0)
                {
                    // First read bytes from the buffer
                    int bytesToRead = Math.Min(this.readBuf.Length - this.readBufPosition, countRemaining);
                    Array.Copy(this.readBuf, this.readBufPosition, buffer, offset, bytesToRead);
                    countRemaining -= bytesToRead;
                    this.position += bytesToRead;
                    this.readBufPosition += bytesToRead;
                    offset += bytesToRead;

                    // If the buffer is depleted, refill it
                    if (this.readBufPosition == this.readBuf.Length && countRemaining > 0)
                    {
                        this.readBuf = this.host.I2CTransfer(
                            this.slaveAddress,
                            new byte[] { (byte)(this.position >> 8), (byte)(this.position & 0xFF) }, 2,
                            (byte)PAGE_SIZE);
                        this.readBufPosition = 0;
                    }
                }

                return count;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                // Empty the read buffer
                this.readBufPosition = this.readBuf.Length;

                switch (origin)
                {
                    case SeekOrigin.Begin:
                        this.position = offset;
                        break;
                    case SeekOrigin.Current:
                        this.position += offset;
                        break;
                    case SeekOrigin.End:
                        this.position = this.length + offset;
                        break;
                }

                return this.position;
            }

            public override void SetLength(long value)
            {
                this.length = value;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                byte[] writeBuf = new byte[PAGE_SIZE + 2];
                while (count > 0)
                {
                    writeBuf[0] = (byte)(this.position >> 8);
                    writeBuf[1] = (byte)(this.position & 0xFF);
                    int bytesToWrite = (int)Math.Min(PAGE_SIZE - (position % PAGE_SIZE), count);
                    Array.Copy(buffer, offset, writeBuf, 2, bytesToWrite);
                    this.host.I2CTransfer(this.slaveAddress, writeBuf, (byte)(bytesToWrite + 2), 0);

                    count -= bytesToWrite;
                    offset += bytesToWrite;
                    this.position += bytesToWrite;
                }

                // Invalidate the read buffer
                this.readBufPosition = this.readBuf.Length;
            }
        }

        public LokiBootloaderHost(CommunicationsChannel channel)
            : base(channel)
        {
        }

        public byte[] I2CTransfer(byte slaveAddress, byte[] sendData, byte sendLen, byte rxLen)
        {
            I2CTransferCommand command = new I2CTransferCommand(_checksumType, slaveAddress, sendData, sendLen, rxLen);
            I2CTransferResponse response = new I2CTransferResponse();
            try
            {
                this.SendCommand(command, response);
            }
            catch (BootloaderError ex)
            {
                if (((int)ex.Status & 0x80) != 0)
                {
                    throw new I2CTransferError(ex);
                }
                else
                {
                    throw;
                }
            }
            if(sendLen > 0)
                System.Threading.Thread.Sleep(5);
            return response.Data;
        }

        public Stream OpenEEPROM(byte slaveAddress, int length)
        {
            return new EEPROMStream(this, slaveAddress, length);
        }

        public LokiInfo GetLokiInfo()
        {
            HIDCommunicationsChannel channel = this._channel as HIDCommunicationsChannel;
            LokiInfo loki = new LokiInfo(
                string.Format("{0} {1} [{2:X}, {3:X}]", channel.Device.Manufacturer, channel.Device.Product, channel.Device.VendorID, channel.Device.ProductID),
                string.Format("{0:X}.{1:X}", this.SiliconId, this.SiliconRev),
                this.bootloaderVersion,
                LOKI_EEPROM_ADDR);
            try
            {
                loki.Deserialize(this.OpenEEPROM(LOKI_EEPROM_ADDR, 65536));
            }
            catch (BoardInfoFormatException) { }
            return loki;
        }

        public BoardInfo[] GetPlankInfo()
        {
            List<BoardInfo> boards = new List<BoardInfo>();
            foreach(byte slaveAddr in PLANK_EEPROM_ADDRS) {
                try
                {
                    boards.Add(new BoardInfo(this.OpenEEPROM(slaveAddr, 65536), slaveAddr));
                }
                catch (I2CTransferError ex)
                {
                    if (((I2CStatusCode)ex.Status) == I2CStatusCode.I2C_MSTR_ERR_LB_NAK)
                    {
                        break;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (BoardInfoFormatException)
                {
                    // Board is present, but doesn't have a valid eeprom
                    BoardInfo plank = new BoardInfo(slaveAddr);
                    plank.PlankName = "Unknown Plank";
                    plank.Version = "";
                    boards.Add(plank);
                }
            }

            return boards.ToArray();
        }
    }
}
