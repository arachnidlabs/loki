using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public interface CommunicationsChannel
    {
        void WriteData(byte[] buffer, int size);

        void ReadData(byte[] buffer, int size);

        void CloseConnection();

        void OpenConnection();

        uint MaxTransferSize { get; }
    }
}
