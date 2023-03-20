using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2_2
{
    public static class HtmlDecoder
    {
        public static string DecodeHTML(TextReader inputStream, TextWriter outputStream)
        {
            string readString = inputStream.ReadLine();
            if (readString == "q")//сделать выход нормальный
                return readString;
            Window window = new Window(outputStream);
            for (int i = 0; i < readString.Length; i++)
            {
                //сделать одну функцию из 3
                window.WriteFirstSymbol();
                window.Push(readString[i].ToString());
                window.Parce();
            }
            window.WriteAllAvailableSymbols();
            return "";
        }
    }
}
