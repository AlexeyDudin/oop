using System;

namespace Lab2_5
{
    public class UrlDecoder
    {
        public static bool ParceString(string input, ref Url url)
        {
            string changedInput = input;
            Url result = new Url();

            try
            {
                result.Protocol = ParceProtocol(ref changedInput);
                result.Host = ParceHost(ref changedInput);
                result.Port = ParcePort(ref changedInput, result.Protocol);
                result.Document = changedInput;

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static ushort ParcePort(ref string input, ProtocolEnum protocol)
        {
            if (string.IsNullOrWhiteSpace(input) || (input[0] == '/'))
                return СomparisonPortProtocol.GetPortByProtocol(protocol);
            input = input.Remove(0, 1);
            string readString = "";
            for (int i = 0; i < input.Length; i++)
            {
                readString += input[i];
                if (readString.EndsWith("/"))
                    break;
            }
            if (readString.EndsWith("/"))
                readString = readString.Substring(0, readString.Length - 2);
            input = input.Remove(0, readString.Length);
            return ushort.Parse(readString);
        }

        private static string ParceHost(ref string input)
        {
            string readString = "";
            for (int i = 0; i < input.Length; i++)
            {
                readString += input[i];
                if (readString.EndsWith("/") || readString.EndsWith(":"))
                    break;
            }
            input = input.Remove(0, readString.Length - 1);
            return readString;
        }

        private static ProtocolEnum ParceProtocol(ref string input)
        {
            string readString = "";
            for (int i = 0; i < input.Length; i++)
            {
                readString += input[i]; 
                if (readString.EndsWith("://"))
                    break;
            }
            readString = readString.ToUpper();
            input = input.Remove(0, readString.Length);
            switch (readString)
            {
                case "HTTP://":
                    return ProtocolEnum.HTTP;
                case "HTTPS://":
                    return ProtocolEnum.HTTPS;
                case "FTP://":
                    return ProtocolEnum.FTP;
                default:
                    throw new FormatException($"Ошибка парсинга строки {input}. Не могу определить тип протокола");
            }
        }
    }
}
