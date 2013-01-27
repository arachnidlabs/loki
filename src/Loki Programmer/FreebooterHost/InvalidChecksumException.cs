using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    class InvalidChecksumException : Exception
    {
        private byte arrayId;
        private ushort rowNumber;

        public InvalidChecksumException(byte arrayId, ushort rowNumber)
            : base(String.Format("Invalid checksum validating row {0} in array {1}", rowNumber, arrayId))
        {
            this.arrayId = arrayId;
            this.rowNumber = rowNumber;
        }

        public InvalidChecksumException()
            : base("Invalid checksum")
        {
        }
    }
}
