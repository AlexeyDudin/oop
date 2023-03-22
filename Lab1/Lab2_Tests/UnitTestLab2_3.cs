using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Lab2_3;
using System.Runtime.Remoting.Messaging;

namespace Lab2_Tests
{
    [TestClass]
    public class UnitTestLab2_3
    {
        [TestMethod]
        public void TestDictionaryExistingWord()
        {
            TextReader tr = new StringReader("red\n...");
            StringWriter sw = new StringWriter();
            var library = new Dictionary();
            library.LoadLibrary("library.json");
            var consoleWorker = new ConsoleWorker(tr, sw);
            consoleWorker.Run(library);
            Assert.AreEqual<string>(">красный\r\n>", sw.ToString());
        }

        [TestMethod]
        public void TestDictionaryAddOneToOneMissingWord()
        {
            TextReader tr = new StringReader("blue\nсиний\nblue\n...\ny");
            StringWriter sw = new StringWriter();
            var library = new Dictionary();
            library.LoadLibrary("library.json");
            var consoleWorker = new ConsoleWorker(tr, sw);
            consoleWorker.Run(library);
            Assert.AreEqual<string>(">Неизвестное слово \"blue\". Введите перевод или пустую строку для отказа.\r\n>Слово \"blue\" сохранено в словаре как \"синий\".\r\n>синий\r\n>В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.\r\n", sw.ToString());
            string ethalonJSON = "{\"FirstWord\":\"blue\",\"SecondWord\":\"\\u0441\\u0438\\u043D\\u0438\\u0439\"}";
            string recieveJSON = File.ReadAllText("library.json");
            Assert.IsTrue(recieveJSON.Contains(ethalonJSON));
        }

        [TestMethod]
        public void TestDictionaryAddOneToManyMissingWord()
        {
            TextReader tr = new StringReader("blue\nсиний, голубой\nголубой\n...\ny");
            StringWriter sw = new StringWriter();
            var library = new Dictionary();
            library.LoadLibrary("library.json");
            var consoleWorker = new ConsoleWorker(tr, sw);
            consoleWorker.Run(library);
            Assert.AreEqual<string>(">Неизвестное слово \"blue\". Введите перевод или пустую строку для отказа.\r\n>Слово \"blue\" сохранено в словаре как \"синий\".\r\nСлово \"blue\" сохранено в словаре как \"голубой\".\r\n>blue\r\n>В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.\r\n", sw.ToString());
            
            string ethalonJSON = "{\"FirstWord\":\"blue\",\"SecondWord\":\"\\u0441\\u0438\\u043D\\u0438\\u0439\"},{\"FirstWord\":\"blue\",\"SecondWord\":\"\\u0433\\u043E\\u043B\\u0443\\u0431\\u043E\\u0439\"}";
            string recieveJSON = File.ReadAllText("library.json");
            Assert.IsTrue(recieveJSON.Contains(ethalonJSON));
        }

        [TestMethod]
        public void TestDictionaryDontSaveChanges()
        {
            TextReader tr = new StringReader("blue\n\n...");
            StringWriter sw = new StringWriter();
            var library = new Dictionary();
            library.LoadLibrary("library.json");
            var consoleWorker = new ConsoleWorker(tr, sw);
            consoleWorker.Run(library);
            string recieveJSON = File.ReadAllText("library.json");

            Assert.IsFalse(recieveJSON.Contains("blue"));
            Assert.AreEqual<string>(">Неизвестное слово \"blue\". Введите перевод или пустую строку для отказа.\r\n>Слово \"blue\" проигнорировано.\r\n>", sw.ToString());
        }
    }
}
