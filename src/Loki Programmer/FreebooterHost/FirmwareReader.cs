using MiscUtil.Conversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public class FirmwareReader : IDisposable
    {
        public class Row
        {
            private byte _arrayId;
            private UInt16 _rowNumber;
            private byte _checksum;
            private byte[] _data;

            public Row(byte[] row)
            {
                _arrayId = row[0];
                _rowNumber = EndianBitConverter.Big.ToUInt16(row, 1);
                
                UInt16 dataLength = EndianBitConverter.Big.ToUInt16(row, 3);
                if (dataLength != row.Length - 6)
                    throw new InvalidDataException();
                _data = new byte[dataLength];
                Array.Copy(row, 5, _data, 0, dataLength);

                _checksum = 0;
                for (int i = 0; i < row.Length - 1; i++)
                    _checksum += row[i];
                _checksum = (byte)(1 + ~_checksum);
                if(_checksum != row[row.Length - 1])
                    throw new InvalidDataException();
            }

            public byte ArrayId
            {
                get
                {
                    return _arrayId;
                }
            }

            public UInt16 RowNumber
            {
                get
                {
                    return _rowNumber;
                }
            }

            public byte[] Data
            {
                get
                {
                    return _data;
                }
            }

            public byte Checksum
            {
                get
                {
                    return _checksum;
                }
            }
        }

        private Stream _inStream;
        private TextReader _reader;
        UInt32 _siliconId;
        byte _siliconRev;
        PacketChecksumType _checksumType;

        public FirmwareReader(Stream inStream) {
            _inStream = inStream;
            _reader = new StreamReader(inStream);
            ReadHeader();
        }

        public UInt32 SiliconId
        {
            get
            {
                return _siliconId;
            }
        }

        public byte SiliconRev
        {
            get
            {
                return _siliconRev;
            }
        }

        public PacketChecksumType ChecksumType
        {
            get
            {
                return _checksumType;
            }
        }

        private byte[] DecodeHex(String line)
        {
            byte[] ret = new byte[line.Length / 2];
            for(int i = 0; i < ret.Length; i++)
                ret[i] = byte.Parse(line.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            return ret;
        }

        private void ReadHeader()
        {
            byte[] header = DecodeHex(_reader.ReadLine());
            _siliconId = EndianBitConverter.Big.ToUInt32(header, 0);
            _siliconRev = header[4];
            _checksumType = (PacketChecksumType) header[5];
        }

        public Row ReadRow()
        {
            String line = _reader.ReadLine();
            if (line == null)
                return null;
            if (!line.StartsWith(":"))
                throw new InvalidDataException();
            return new Row(DecodeHex(line.Substring(1)));
        }

        public void Close()
        {
            _reader.Close();
        }

        public void Dispose()
        {
            this.Close();
        }

        public long Position
        {
            get { return _inStream.Position; }
        }

        public long Length
        {
            get { return _inStream.Length; }
        }
    }
}
