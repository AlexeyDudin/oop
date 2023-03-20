using System;
using System.IO;

namespace Lab2_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Url url = new Url();
            UrlDecoder.ParceString(Console.ReadLine(), ref url);
            url.Print(Console.Out);
        }
    }
}
