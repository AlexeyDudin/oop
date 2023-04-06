using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_5
{
    public static class СomparisonPortProtocol
    {
        public static Dictionary<ProtocolEnum, ushort> CurrentDictionary = new Dictionary<ProtocolEnum, ushort>()
        {
            { ProtocolEnum.HTTP, 80 },
            { ProtocolEnum.HTTPS, 443 },
            { ProtocolEnum.FTP, 21}
        };

        public static ushort GetPortByProtocol(ProtocolEnum protocol)
        {
            ushort result = 0;
            if (CurrentDictionary.TryGetValue(protocol, out result))
                return result;
            else
                throw new ArgumentException($"Что-то пошло не так при извлечении значения порта по протоколу: {protocol.ToString()}");
        }
    }
}
