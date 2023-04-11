using System;
using System.Text.RegularExpressions;

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
                result.Protocol = ParceProtocol(changedInput);
                result.Host = ParceHost(changedInput);
                result.Port = ParcePort(changedInput, result.Protocol);
                result.Document = ParceDocument(changedInput, GetHostPortString(changedInput));

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static string GetHostPortString(string input)
        {
            string regularExpression = @"/\D*";
            return GetStringByReqularExpr(input, regularExpression, 3);
        }

        private static string ParceDocument(string input, string hostPortString)
        {
            string regularExpression = $"{hostPortString}/\\D*$";
            string readString = GetStringByReqularExpr(input, regularExpression);
            readString = readString.Replace(hostPortString + "/", "");
            return readString;
        }

        private static ushort ParcePort(string input, ProtocolEnum protocol)
        {
            string regularExpression = @":\d+";
            string readString = GetStringByReqularExpr(input, regularExpression);
            readString = readString.Replace(":", "");
            if (string.IsNullOrWhiteSpace(readString))
                return СomparisonPortProtocol.GetPortByProtocol(protocol);
            return ushort.Parse(readString);
        }

        private static string ParceHost(string input)
        {
            string regularExpression = @"((://)\D*[:/])";
            string readString = GetStringByReqularExpr(input, regularExpression);
            readString = readString.Substring(3, readString.Length - 4);
            //for (int i = 0; i < input.Length; i++)
            //{
            //    readString += input[i];
            //    if (readString.EndsWith("/") || readString.EndsWith(":"))
            //        break;
            //}
            //input = input.Remove(0, readString.Length - 1);
            return readString;
        }

        private static ProtocolEnum ParceProtocol(string input)
        {
            string regularExpression = @"(^\D*://)";

            //string readString = "";
            //for (int i = 0; i < input.Length; i++)
            //{
            //    readString += input[i]; 
            //    if (readString.EndsWith("://"))
            //        break;
            //}

            string readString = GetStringByReqularExpr(input, regularExpression);
            readString = readString.ToUpper();
            //input = input.Remove(0, readString.Length);
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

        private static string GetStringByReqularExpr(string input, string regularExpression, int position = 0)
        {
            Regex regex = new Regex(regularExpression, RegexOptions.IgnoreCase);
            Match match;
            if (position == 0)
                match = regex.Match(input);
            else
                match = regex.Matches(input)[position];
            return match.Value;
        }
    }
}
