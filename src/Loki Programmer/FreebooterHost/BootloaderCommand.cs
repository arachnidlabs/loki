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
    public abstract class BootloaderCommand
    {
        private PacketChecksumType _checksumType;

        public BootloaderCommand(PacketChecksumType checksumType)
        {
            this._checksumType = checksumType;
        }

        public byte[] Serialize()
        {
            MemoryStream ms = new MemoryStream();
            EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Little, ms);

            writer.Write((byte)0x01); // Begin command
            writer.Write(this.CommandCode); // Code
            writer.Write((UInt16)0x0000); // Fill in the length later
            this.SerializePayload(writer);
            writer.Seek(2, SeekOrigin.Begin); // Go back and write the length
            writer.Write((UInt16)(ms.Length - 4));
            writer.Seek(0, SeekOrigin.End);
            ushort checksum = PacketChecksum.ComputeChecksum(this._checksumType, ms.GetBuffer(), ms.Length);
            writer.Write(checksum);
            writer.Write((byte)0x17);

            byte[] ret = new byte[ms.Length];
            Array.Copy(ms.GetBuffer(), ret, ms.Length);
            return ret;
        }

        public abstract void SerializePayload(EndianBinaryWriter writer);

        public abstract byte CommandCode { get; }
    }

    public class EnterBootloaderCommand : BootloaderCommand
    {
        public EnterBootloaderCommand(PacketChecksumType checksumType) : base(checksumType) { }

        public override byte CommandCode
        {
            get { return 0x38; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            return;
        }
    }

    public class GetFlashSizeCommand : BootloaderCommand
    {
        private byte _flashArrayId;

        public GetFlashSizeCommand(PacketChecksumType checksumType, byte flashArrayId) : base(checksumType)
        {
            this._flashArrayId = flashArrayId;
        }

        public override byte CommandCode { get { return 0x32; } }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            writer.Write((byte)_flashArrayId);
        }
    }

    public class ProgramRowCommand : BootloaderCommand
    {
        private byte _flashArrayId;
        private UInt16 _flashRowNumber;
        private byte[] _data;

        public ProgramRowCommand(PacketChecksumType checksumType, byte flashArrayId, UInt16 flashRowNumber, byte[] data)
            : base(checksumType)
        {
            this._flashArrayId = flashArrayId;
            this._flashRowNumber = flashRowNumber;
            this._data = data;
        }

        public override byte CommandCode { get { return 0x39; } }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            writer.Write(_flashArrayId);
            writer.Write(_flashRowNumber);
            writer.Write(_data);
        }
    }

    public class EraseRowCommand : BootloaderCommand
    {
        private byte _flashArrayId;
        private UInt16 _flashRowNumber;

        public EraseRowCommand(PacketChecksumType checksumType, byte flashArrayId, UInt16 flashRowNumber) : base(checksumType)
        {
            _flashArrayId = flashArrayId;
            _flashRowNumber = flashRowNumber;
        }

        public override byte CommandCode
        {
            get { return 0x34; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            writer.Write(_flashArrayId);
            writer.Write(_flashRowNumber);
        }
    }

    public class VerifyRowCommand : BootloaderCommand
    {
        private byte _flashArrayId;
        private UInt16 _flashRowNumber;

        public VerifyRowCommand(PacketChecksumType checksumType, byte flashArrayId, UInt16 flashRowNumber) : base(checksumType)
        {
            _flashArrayId = flashArrayId;
            _flashRowNumber = flashRowNumber;
        }

        public override byte CommandCode
        {
            get { return 0x3A; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            writer.Write(_flashArrayId);
            writer.Write(_flashRowNumber);
        }
    }

    public class VerifyChecksumCommand : BootloaderCommand
    {
        public VerifyChecksumCommand(PacketChecksumType checksumType) : base(checksumType) { }

        public override byte CommandCode
        {
            get { return 0x31; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
        }
    }

    public class SendDataCommand : BootloaderCommand
    {
        public byte[] _data;

        public SendDataCommand(PacketChecksumType checksumType, byte[] data)
            : base(checksumType)
        {
            _data = data;
        }

        public override byte CommandCode
        {
            get
            {
                return 0x37;
            }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
            writer.Write(_data);
        }
    }

    public class SyncBootloaderCommand : BootloaderCommand
    {
        public SyncBootloaderCommand(PacketChecksumType checksumType) : base(checksumType) { }

        public override byte CommandCode
        {
            get { return 0x35; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
        }
    }

    public class ExitBootloaderCommand : BootloaderCommand
    {
        public ExitBootloaderCommand(PacketChecksumType checksumType) : base(checksumType) { }

        public override byte CommandCode
        {
            get { return 0x3B; }
        }

        public override void SerializePayload(EndianBinaryWriter writer)
        {
        }
    }
}
