using System.Text;
using System.Text.RegularExpressions;
//Введите URL: hTtP://google.com:123/
//сделать тесты на UpperCase
//запретить порт 0! + тесты
//исправить warnings
namespace Lab6_1
{
    public class CHttpUrl
    {
        private string _domain = "";
        private string _document = "";
        private Protocol _protocol;
        private ushort _port;

        public CHttpUrl(string url)
        {
            ParseUrl(url);
        }

        public CHttpUrl(string domain, string document, Protocol protocol)
        {
            if (string.IsNullOrWhiteSpace(domain))
                throw new CParseUrlException($"Значение domain пустое");
            _domain = domain;
            _document = document;
            _protocol = protocol;
            _port = CHttpUrlHelper.ProtocolToPort[_protocol];
        }
        public CHttpUrl(string domain, string document, Protocol protocol, ushort port)
        {
            if (string.IsNullOrWhiteSpace(domain))
                throw new CParseUrlException($"Значение domain пустое");
            if (_port < CHttpUrlHelper.MIN_PORT || (_port > CHttpUrlHelper.MAX_PORT))
                throw new CParseUrlException($"Значение port должно быть в диапазоне от 1 до 65535");
            _domain = domain;
            _document = document;
            _protocol = protocol;
            _port = port;
        }

        public string GetURL()
        {
            string result = $"{_protocol.ToString().ToLower()}{CHttpUrlHelper.DELIMITER_AFTER_PROTOCOL}{_domain}{CHttpUrlHelper.DELIMITER_BEFORE_PORT}{_port}";
            if (_document != null)
                result += $"{CHttpUrlHelper.DELIMITER_BEFORE_DOCUMENT}{_document}";
            return result;
        }

        public string GetDomain()
        {
            return _domain;
        }

        public string GetDocument()
        {
            return _document;
        }

        public Protocol GetProtocol() 
        {
            return _protocol;
        }

        public ushort GetPort()
        {
            return _port;
        }

        public static implicit operator string(CHttpUrl httpUrl)
        {
            return httpUrl.GetURL();
        }

        public static explicit operator CHttpUrl(string url)
        {
            return new CHttpUrl(url);
        }

        public static implicit operator TextWriter(CHttpUrl date)
        {
            return new StringWriter(new StringBuilder(date.GetURL()));
        }

        public static explicit operator CHttpUrl(TextReader reader)
        {
            string? readedString = reader.ReadLine();
            if (!string.IsNullOrWhiteSpace(readedString))
                return new CHttpUrl(readedString);
            else
                throw new CParseUrlException("Ошибка парсинга входного потока");
        }

        private static Protocol GetProtocolByString(string str)
        {
            return str switch
            {
                "http" => Protocol.HTTP,
                "https" => Protocol.HTTPS,
                _ => throw new CParseUrlException("Ошибка парсинга протокола"),
            };
        }

        private void ParseUrl(string url)
        {
            string regularExpression = @"((^https?)://)([0-9A-z#@%$~_?+\-=.&]*)(:(\d+))?(/(\S*))?";
            var match = Regex.Match(url.ToLower(), regularExpression);
            if (match.Success)
            {
                var protocolString = match.Groups[2].Value;
                _protocol = GetProtocolByString(protocolString);
                _domain = match.Groups[3].Value;
                if (match.Groups[4].Value.StartsWith(":"))
                    _port = ushort.Parse(match.Groups[5].Value);
                else
                    _port = CHttpUrlHelper.ProtocolToPort[_protocol];
                if (_port < CHttpUrlHelper.MIN_PORT || (_port > CHttpUrlHelper.MAX_PORT))
                    throw new CParseUrlException("Значение port должно быть в диапазоне от 1 до 65535");
                _document = match.Groups[7].Value;
            }
            else
                throw new CParseUrlException("Не могу распарсить строку");
        }
    }
}
