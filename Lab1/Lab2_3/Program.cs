using System;

namespace Lab2_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary library = new Dictionary();
            library.LoadLibrary("library.json");
            ConsoleWorker consoleWorker = new ConsoleWorker(Console.In, Console.Out);
            consoleWorker.Run(library);
        }
    }
}
