namespace Lab6_1
{
    public static class CHttpUrlHelper
    {
        public const string DELIMITER_AFTER_PROTOCOL = "://";
        public const string DELIMITER_BEFORE_PORT = ":";
        public const string DELIMITER_BEFORE_DOCUMENT = "/";

        public const ushort MIN_PORT = 1;
        public const ushort MAX_PORT = 65535;

        public static Dictionary<Protocol, ushort> ProtocolToPort = new Dictionary<Protocol, ushort>() { { Protocol.HTTP, 80 }, { Protocol.HTTPS, 413 } };
    }
}
