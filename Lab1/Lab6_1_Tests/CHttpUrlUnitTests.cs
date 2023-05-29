using Lab6_1;

namespace Lab6_1_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("http://www.google.com:413/test1", Protocol.HTTP, "www.google.com", (ushort)413, "test1", "http://www.google.com:413/test1")]
        [TestCase("https://www.google.com:413/test1", Protocol.HTTPS, "www.google.com", (ushort)413, "test1", "https://www.google.com:413/test1")]
        [TestCase("http://www.google.com/test1", Protocol.HTTP, "www.google.com", (ushort)80, "test1", "http://www.google.com:80/test1")]
        [TestCase("https://www.google.com/test1", Protocol.HTTPS, "www.google.com", (ushort)413, "test1", "https://www.google.com:413/test1")]
        [TestCase("http://www.google.com:80", Protocol.HTTP, "www.google.com", (ushort)80, "", "http://www.google.com:80/")]
        [TestCase("http://www.google.com:413", Protocol.HTTP, "www.google.com", (ushort)413, "", "http://www.google.com:413/")]
        [TestCase("http://www.google.com", Protocol.HTTP, "www.google.com", (ushort)80, "", "http://www.google.com:80/")]
        [TestCase("HtTp://wWw.gOOgle.com", Protocol.HTTP, "www.google.com", (ushort)80, "", "http://www.google.com:80/")]
        public void TestParseUrl_Ok(string url, Protocol protocot, string domain, ushort port, string document, string expectedUrl)
        {
            CHttpUrl result1 = new(url);
            CHttpUrl result2 = (CHttpUrl)url;
            Assert.That(protocot, Is.EqualTo(result1.GetProtocol()));
            Assert.That(domain, Is.EqualTo(result1.GetDomain()));
            Assert.That(port, Is.EqualTo(result1.GetPort()));
            Assert.That(document, Is.EqualTo(result1.GetDocument()));
            Assert.That(expectedUrl, Is.EqualTo(result1.GetURL()));
            Assert.That(expectedUrl, Is.EqualTo((string)result2));
        }

        [Test]
        [TestCase("ftp://www.google.com:413/test1")]
        [TestCase("httpsq://www.google.com:413/test1")]
        [TestCase("1234")]
        [TestCase(" http://www.google.com")]
        [TestCase("http://www.google.com:0")]
        [TestCase("http://www.google.com:65536")]
        public void TestParseUrl_Bad(string url)
        {
            Assert.Throws<CParseUrlException>(() => new CHttpUrl(url));
        }

        [Test]
        [TestCase("www.google.com", "test1", Protocol.HTTP, (ushort)413, "http://www.google.com:413/test1")]
        [TestCase("www.google.com", "", Protocol.HTTPS, null, "https://www.google.com:413/")]
        public void TestCHttpUrlConstructor_OK(string domain, string document, Protocol protocol, ushort? port, string expectedUrl)
        {
            CHttpUrl result;
            if (port != null)
                result = new CHttpUrl(domain, document, protocol, port.Value);
            else
                result = new CHttpUrl(domain, document, protocol);
            Assert.That(expectedUrl, Is.EqualTo(result.GetURL()));
        }

        [Test]
        [TestCase("", "test1", Protocol.HTTP, (ushort)413)]
        [TestCase("", "", Protocol.HTTPS, null)]
        [TestCase(" ", "test1", Protocol.HTTP, (ushort)413)]
        [TestCase(" ", "", Protocol.HTTPS, null)]
        public void TestCHttpUrlConstructor_Bad(string domain, string document, Protocol protocol, ushort? port)
        {
            if (port != null)
                Assert.Throws<CParseUrlException>(() => new CHttpUrl(domain, document, protocol, port.Value));
            else
                Assert.Throws<CParseUrlException>(() => new CHttpUrl(domain, document, protocol));
        }
    }
}