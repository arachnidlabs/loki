using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    class BoardInfoFormatException : Exception
    {
        public BoardInfoFormatException() { }

        public BoardInfoFormatException(string p) : base(p) { }
    }
}
