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
        private static NameValueCollection dictionary = new NameValueCollection()
        {
            { "&quot;", "\"" },
            { "&apos;", "\'" },
            { "&lt;", "<" },
            { "&gt;" , ">" },
            { "&amp;" , "&"}
        };

        private static void MoveWindow(ref string[] window)
        {
            for (int i = 0; i < window.Length - 1; i++)
                window[i] = window[i + 1];
        }

        private static void ParceWindow(ref string[] window, TextWriter textWriter)
        {
            var calculateString = GetString(window);
            foreach (var key in dictionary.AllKeys)
            {
                if (calculateString.Contains(key))
                { 
                    RemoveCharsInWindow(ref window, key);
                    WriteAllChars(window, textWriter);
                    RemoveCharsInWindow(ref window, window.Length);
                    WriteSymbol(textWriter, dictionary[key]);
                    break;
                }
            }
        }

        private static void WriteAllChars(string[] window, TextWriter textWriter)
        {
            foreach (var element in window)
            {
                WriteSymbol(textWriter, element);
            }
        }

        private static void RemoveCharsInWindow(ref string[] window, string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                window[window.Length - 1 - i] = "";
            }
        }
        private static void RemoveCharsInWindow(ref string[] window, int size)
        {
            for (int i = 0; i < size; i++)
            {
                window[window.Length - 1 - i] = "";
            }
        }

        private static string GetString(string[] window)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in window)
            {
                sb.Append(elem);
            }
            return sb.ToString();
        }

        private static void WriteSymbol(TextWriter outputStream, string value)
        {
            if (value != "")
                outputStream.Write(value);
        }

        private static int GetMaxKeyLenght()
        {
            int maxLenght = 0;
            foreach (var key in dictionary.AllKeys)
            {
                if (maxLenght < key.Length)
                    maxLenght = key.Length;
            }
            return maxLenght;
        }

        private static string[] InitializeWindow()
        {
            int maxLenght = GetMaxKeyLenght();
            return new string[maxLenght];
        }

        public static string DecodeHTML(TextReader inputStream, TextWriter outputStream)
        {
            string readString = inputStream.ReadLine();
            if (readString == "q")
                return readString;
            string[] window = InitializeWindow();
            for (int i = 0; i < readString.Length; i++)
            {
                WriteSymbol(outputStream, window[0]);
                MoveWindow(ref window);

                window[window.Length - 1] = readString[i].ToString();

                ParceWindow(ref window, outputStream);
            }
            WriteAllChars(window, outputStream);
            outputStream.WriteLine();
            return "";
        }
    }
}
