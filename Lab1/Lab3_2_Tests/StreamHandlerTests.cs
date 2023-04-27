using Lab3_2;

namespace Lab3_2_Tests
{
    public class Tests
    {
        [Test]
        public void Work_InputEmptyString_ShouldPrintErrorAndCallPrintCommandsHelp()
        {
            var input = new StringReader("\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� ������ ������!\r\n������ ��������� �������: \r\nvar\r\nprint\r\nlet\r\nfn\r\nprintvars\r\nprintfns\r\n������� �������: "));
        }

        [Test]
        public void Work_InputUnknownCommand_ShouldPrintErrorAndCallPrintCommandsHelp()
        {
            var input = new StringReader("unknown\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: �� ��������� ��������\r\n������ ��������� �������: \r\nvar\r\nprint\r\nlet\r\nfn\r\nprintvars\r\nprintfns\r\n������� �������: "));
        }

        [Test]
        public void Work_InputCorrectCommand_Method_Var()
        {
            var input = new StringReader("var x\nprint x\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� �������: nan\r\n������� �������: "));
        }

        [Test]
        public void Work_InputCorrectCommand_Method_Let()
        {
            var input = new StringReader("let x = 5\nprint x\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� �������: 5.00\r\n������� �������: "));
        }

        [Test]
        public void Work_InputCorrectCommand_Method_FunctionInitialize()
        {
            var input = new StringReader("let x = 4\nfn fnx = 5 * x\nprint fnx\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� �������: ������� �������: 20.00\r\n������� �������: "));
        }

        [Test]
        public void Work_InputCorrectCommand_Method_PrintVars()
        {
            var input = new StringReader("let x = 4\nlet y = 5\nprintvars\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� �������: ������� �������: x:4.00\r\ny:5.00\r\n������� �������: "));
        }

        [Test]
        public void Work_InputCorrectCommand_Method_PrintFns()
        {
            var input = new StringReader("let x = 4\nfn fnx1 = 5 * x\nfn fnx2=10 * x\nprintfns\nquit");
            var output = new StringWriter();
            var streamHandler = new StreamHandler(input, output);

            streamHandler.Work();

            Assert.That(output.ToString(), Is.EqualTo("������� �������: ������� �������: ������� �������: ������� �������: fnx1:20.00\r\nfnx2:40.00\r\n������� �������: "));
        }
    }
}