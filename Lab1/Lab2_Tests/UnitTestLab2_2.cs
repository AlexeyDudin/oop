using Lab2_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Lab2_Tests
{
    [TestClass]
    public class UnitTestLab2_2
    {
        [TestMethod]
        public void TestOkFirst()
        {
            TextReader tr = new StringReader("Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s");
            StringWriter sw = new StringWriter();
            string result = HtmlDecoder.DecodeHTML(tr, sw);
            Assert.IsTrue(string.IsNullOrEmpty(result));
            Assert.AreEqual<string>("Cat <says> \"Meow\". M&M's", sw.ToString());
        }

        [TestMethod]
        public void TestEmptyString()
        {
            TextReader tr = new StringReader("");
            StringWriter sw = new StringWriter();
            string result = HtmlDecoder.DecodeHTML(tr, sw);
            Assert.IsTrue(string.IsNullOrEmpty(result));
            Assert.AreEqual("", sw.ToString());
        }
    }
}
