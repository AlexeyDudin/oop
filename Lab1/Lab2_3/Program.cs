using System;

namespace Lab2_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadLibrary("library.json");
            ConsoleWorker consoleWorker = new ConsoleWorker(Console.In, Console.Out);
            consoleWorker.Run(library);
        }
    }
}
