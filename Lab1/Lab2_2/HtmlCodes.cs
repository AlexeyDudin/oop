using System.Collections.Specialized;

namespace Lab2_2
{
    public class HtmlCodes
    {
        public static NameValueCollection Dictionary = new NameValueCollection()
        {
            { "&quot;", "\"" },
            { "&apos;", "\'" },
            { "&lt;", "<" },
            { "&gt;" , ">" },
            { "&amp;" , "&"}
        };
    }
}
