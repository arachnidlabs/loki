using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LokiProgrammer
{
    public enum I2CStatusCode
    {
        I2C_MSTR_NO_ERROR = 0x80,
        I2C_MSTR_BUS_BUSY = 0x81,
        I2C_MSTR_NOT_READY = 0x82,
        I2C_MSTR_ERR_LB_NAK = 0x83,
        I2C_MSTR_ERR_ARB_LOST = 0x84,
        I2C_MSTR_ERR_ABORT_START_GEN = 0x85,
    }

    class I2CTransferError : BootloaderError
    {
        public I2CTransferError(BootloaderError ex)
            : base(ex, String.Format("Got status code {0}: {1} from bootloader", (int)ex.Status, ((I2CStatusCode) ex.Status).ToString()))
        {
        }

        public I2CStatusCode I2CStatus
        {
            get { return (I2CStatusCode)this.Status; }
        }
    }
}
