using CyUSB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public class HIDCommunicationsChannel : CommunicationsChannel
    {
        private CyHidDevice _device;

        public CyHidDevice Device
        {
            get
            {
                return _device;
            }
        }

        public HIDCommunicationsChannel(CyHidDevice device)
        {
            this._device = device;
        }

        public void WriteData(byte[] buffer, int size)
        {
            byte[] data = new byte[64];

            //First Byte in buffer holds the Report ID
            _device.Outputs.DataBuf[0] = _device.Outputs.ID;
            Array.Copy(buffer, 0, _device.Outputs.DataBuf, 1, size);

            if (!_device.WriteOutput())
                throw new CommunicationsError();

            /* Cypress's code suggests a delay is needed here for successful bootloading, but
             * empirical testing suggests otherwise. Uncomment this if it becomes a problem. */
            //System.Threading.Thread.Sleep(100);
        }

        public void ReadData(byte[] buffer, int size)
        {
            if (!_device.ReadInput())
                throw new CommunicationsError();
            Array.Copy(_device.Inputs.DataBuf, 1, buffer, 0, size);
        }

        public void CloseConnection()
        {
        }

        public void OpenConnection()
        {
        }

        public uint MaxTransferSize
        {
            get { return 64; }
        }
    }
}
