using Lab2_5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Lab2_Tests
{
    [TestClass]
    public class UnitTestLab2_5
    {
        [TestMethod]
        public void TestHttpWithPort()
        {
            Url url = new Url();
            string stringUrl = @"http://www.google.com:8080/123";
            UrlDecoder.ParceString(stringUrl, ref url);
            Url resultUrl = new Url();
            resultUrl.Host = "www.google.com";
            resultUrl.Port = 8080;
            resultUrl.Protocol = ProtocolEnum.HTTP;
            resultUrl.Document = "123";
            Assert.AreEqual<Url>(resultUrl, url);
        }

        [TestMethod]
        public void TestHttpsWithPort()
        {
            Url url = new Url();
            string stringUrl = @"https://www.google.com:8080/123";
            UrlDecoder.ParceString(stringUrl, ref url);
            Url resultUrl = new Url();
            resultUrl.Host = "www.google.com";
            resultUrl.Port = 8080;
            resultUrl.Protocol = ProtocolEnum.HTTPS;
            resultUrl.Document = "123";
            Assert.AreEqual<Url>(resultUrl, url);
        }

        [TestMethod]
        public void TestFtpWithPort()
        {
            Url url = new Url();
            string stringUrl = @"ftp://www.google.com:8080/123";
            UrlDecoder.ParceString(stringUrl, ref url);
            Url resultUrl = new Url();
            resultUrl.Host = "www.google.com";
            resultUrl.Port = 8080;
            resultUrl.Protocol = ProtocolEnum.FTP;
            resultUrl.Document = "123";
            Assert.AreEqual<Url>(resultUrl, url);
        }

        [TestMethod]
        public void TestWithoutPort()
        {
            Url url = new Url();
            string stringUrl = @"http://www.google.com/123";
            UrlDecoder.ParceString(stringUrl, ref url);
            Url resultUrl = new Url();
            resultUrl.Host = "www.google.com";
            resultUrl.Port = СomparisonPortProtocol.GetPortByProtocol(ProtocolEnum.HTTP);
            resultUrl.Protocol = ProtocolEnum.HTTP;
            resultUrl.Document = "123";
            Assert.AreEqual<Url>(resultUrl, url);
        }
    }
}
