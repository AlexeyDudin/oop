namespace Lab6_1
{
    public class ConsoleWorker
    {
        private readonly TextReader input;
        private readonly TextWriter output;

        public ConsoleWorker(TextReader input, TextWriter output)
        { 
            this.input = input;
            this.output = output;
        }

        public void Run()
        {
            output.Write("Введите URL: ");
            string? readString;
            while (!string.IsNullOrWhiteSpace(readString = input.ReadLine()))
            {
                try
                {
                    var myHttpUrl = new CHttpUrl(readString);
                    output.WriteLine($"Protocol:{myHttpUrl.GetProtocol()}");
                    output.WriteLine($"Domain:{myHttpUrl.GetDomain()}");
                    output.WriteLine($"Port:{myHttpUrl.GetPort()}");
                    output.WriteLine($"Document:{myHttpUrl.GetDocument()}");
                    output.WriteLine($"URL:{myHttpUrl.GetURL()}");
                }
                catch (Exception e)
                {
                    output.WriteLine(e.Message);
                }
                output.Write("Введите URL: ");
            }
        }
    }
}
