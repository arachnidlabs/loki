using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    class UnsupportedDeviceException : Exception
    {
        private uint actualSiliconId;
        private byte actualSiliconRev;
        private uint expectedSiliconId;
        private byte expectedSiliconRev;

        public UnsupportedDeviceException(uint actualSiliconId, byte actualSiliconRev, uint expectedSiliconId, byte expectedSiliconRev)
            : base(String.Format("Expected device {0}:{1}, but hardware is {2}:{3}", expectedSiliconId, expectedSiliconRev, actualSiliconId, actualSiliconRev))
        {
            this.actualSiliconId = actualSiliconId;
            this.actualSiliconRev = actualSiliconRev;
            this.expectedSiliconId = expectedSiliconId;
            this.expectedSiliconRev = expectedSiliconRev;
        }
    }
}
