using MiscUtil.Conversion;
using MiscUtil.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public enum StatusCode
    {
        CYRET_SUCCESS = 0x00,
        BOOTLOADER_ERR_VERIFY = 0x02,
        BOOTLOADER_ERR_LENGTH = 0x03,
        BOOTLOADER_ERR_DATA = 0x04,
        BOOTLOADER_ERR_CMD = 0x05,
        BOOTLOADER_ERR_DEVICE = 0x06,
        BOOTLOADER_ERR_VERSION = 0x07,
        BOOTLOADER_ERR_CHECKSUM = 0x08,
        BOOTLOADER_ERR_ARRAY = 0x09,
        BOOTLOADER_ERR_ROW = 0x0A,
        BOOTLOADER_ERR_APP = 0x0C,
        BOOTLOADER_ERR_ACTIVE = 0x0D,
        BOOTLOADER_ERR_UNK = 0x0F
    }

    public abstract class BootloaderResponse
    {
        public void Deserialize(PacketChecksumType checksumType, byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            EndianBinaryReader reader = new EndianBinaryReader(EndianBitConverter.Little, ms);
            if (reader.ReadByte() != 0x01)
                throw new InvalidDataException("Message start byte must be 0x01");
            StatusCode status = (StatusCode) reader.ReadByte();
            if (status != StatusCode.CYRET_SUCCESS)
                throw new BootloaderError(status);
            ushort length = reader.ReadUInt16();
            if (length > data.Length - 7)
                throw new InvalidDataException("Invalid data length");
            this.DeserializePayload(reader, length);
            ushort checksum = reader.ReadUInt16();
            if (checksum != PacketChecksum.ComputeChecksum(checksumType, data, length + 4))
                throw new InvalidDataException("Invalid checksum");
            if (reader.ReadByte() != 0x17)
                throw new InvalidDataException("Message end byte must be 0x17");
        }

        public abstract void DeserializePayload(EndianBinaryReader reader, ushort length);
    }

    public class EnterBootloaderResponse : BootloaderResponse
    {
        private UInt32 _siliconId;
        private byte _siliconRev;
        private UInt32 _version; 

        public override void DeserializePayload(EndianBinaryReader reader, ushort length)
        {
            this._siliconId = reader.ReadUInt32();
            this._siliconRev = reader.ReadByte();
            this._version = reader.ReadUInt16();
            this._version |= (UInt32)(reader.ReadByte() << 16);
        }

        public UInt32 SiliconId { get { return _siliconId; } }
        
        public byte SiliconRev { get { return _siliconRev; } }

        public UInt32 Version { get { return _version; } }
    }

    public class GetFlashSizeResponse : BootloaderResponse
    {
        private UInt16 _firstRow;
        private UInt16 _lastRow;

        public override void DeserializePayload(EndianBinaryReader reader, ushort length)
        {
            this._firstRow = reader.ReadUInt16();
            this._lastRow = reader.ReadUInt16();
        }

        public UInt16 FirstRow { get { return _firstRow; } }

        public UInt16 LastRow { get { return _lastRow; } }
    }

    public class EmptyResponse : BootloaderResponse
    {
        public override void DeserializePayload(EndianBinaryReader reader, ushort length) { }
    }

    public class VerifyRowResponse : BootloaderResponse
    {
        private byte _checksum;

        public override void DeserializePayload(EndianBinaryReader reader, ushort length)
        {
            _checksum = reader.ReadByte();
        }

        public byte Checksum { get { return _checksum; } }
    }

    public class VerifyChecksumResponse : BootloaderResponse
    {
        private byte _checksumValid;

        public override void DeserializePayload(EndianBinaryReader reader, ushort length)
        {
            _checksumValid = reader.ReadByte();
        }

        public Boolean ChecksumValid
        {
            get
            {
                return _checksumValid != 0;
            }
        }
    }
}
