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
       

        private static void WriteSymbol(TextWriter outputStream, string value)
        {
            if (value != "")
                outputStream.Write(value);
        }

        public static string DecodeHTML(TextReader inputStream, TextWriter outputStream)
        {
            string readString = inputStream.ReadLine();
            if (readString == "q")
                return readString;
            Window window = new Window(outputStream);
            for (int i = 0; i < readString.Length; i++)
            {
                window.WriteFirstSymbol();
                window.MoveWindow();

                window.SetLastCharacter(readString[i].ToString());

                window.Parce();
            }
            window.WriteAllSymbols();

            outputStream.WriteLine();
            return "";
        }
    }
}
