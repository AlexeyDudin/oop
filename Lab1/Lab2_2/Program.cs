using System;

namespace Lab2_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputStream = Console.In;
            var outputStream = Console.Out;
            while (true) 
            {
                Console.Clear();
                Console.Write("Введите HTML-код (введите \'q\' для выхода из программы): ");
                if (HtmlDecoder.DecodeHTML(inputStream, outputStream) == "q")
                    break;
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
        }
    }
}
