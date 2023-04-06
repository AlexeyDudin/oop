using System;
using System.IO;

namespace Lab2_5
{
    public class Url
    {
        public ProtocolEnum Protocol { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public string Document { get; set; }

        public void Print(TextWriter _out)
        {
            _out.WriteLine($"Protocol: {this.Protocol.ToString()}");
            _out.WriteLine($"Host: {this.Host}");
            _out.WriteLine($"Port: {this.Port}");
            _out.WriteLine($"Document: {this.Document}");
        }

        public override bool Equals(object obj)
        {
            var getObj = (Url)obj;
            if (getObj == null) 
                return false;
            return (getObj.Host == this.Host && getObj.Port == this.Port && getObj.Protocol == this.Protocol && getObj.Document == this.Document);
        }
    }
}
