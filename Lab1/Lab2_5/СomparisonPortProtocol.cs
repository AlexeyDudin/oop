using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_5
{
    public static class СomparisonPortProtocol
    {
        public static Dictionary<ProtocolEnum, ushort> Dictionary = new Dictionary<ProtocolEnum, ushort>()
        {
            { ProtocolEnum.HTTP, 80 },
            { ProtocolEnum.HTTP, 443 },
            { ProtocolEnum.FTP, 21}
        };

        public static ushort GetPortByProtocol(ProtocolEnum protocol)
        {
            return Dictionary[protocol];
        }
    }
}
