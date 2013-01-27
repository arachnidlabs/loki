using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    public class BootloaderError : Exception
    {
        private StatusCode status;

        public BootloaderError(StatusCode status)
            : base(String.Format("Got status code {0}: {1} from bootloader", (int)status, status.ToString()))
        {
            this.status = status;
        }

        public BootloaderError(BootloaderError ex, String message)
            : base(message, ex)
        {
            this.status = ex.status;
        }

        public StatusCode Status
        {
            get
            {
                return status;
            }
        }
    }
}
