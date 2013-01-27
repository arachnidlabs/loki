using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    class UnsupportedBootloaderException : Exception
    {
        private UInt32 bootloaderVersion;

        public UnsupportedBootloaderException(UInt32 bootloaderVersion)
            : base(String.Format("Bootloader version {0} is unsupported.", bootloaderVersion))
        {
            this.bootloaderVersion = bootloaderVersion;
        }
    }
}
