using System;
using System.IO;
using System.Text;

namespace Lab2_2
{
    public class Window
    {
        private readonly TextWriter _textWriter;

        public Window(TextWriter textWriter)
        {
            _textWriter = textWriter;
            int maxLenght = GetMaxKeyLenght();
            window = new string[maxLenght];
        }

        private string[] window;

        private void WriteSymbol(string value)
        {
            if (value != "")
                _textWriter.Write(value);
        }
        private string GetString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in window)
            {
                sb.Append(elem);
            }
            return sb.ToString();
        }
        private int GetMaxKeyLenght()
        {
            int maxLenght = 0;
            foreach (var key in HtmlCodes.Dictionary.AllKeys)
            {
                if (maxLenght < key.Length)
                    maxLenght = key.Length;
            }
            return maxLenght;
        }
        private static void RemoveCharsInWindow(ref string[] window, int size)
        {
            for (int i = 0; i < size; i++)
            {
                window[window.Length - 1 - i] = "";
            }
        }

        private void RemoveCharsInWindow(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                window[window.Length - 1 - i] = "";
            }
        }

        public void Parce()
        {
            var calculateString = GetString();
            foreach (var key in HtmlCodes.Dictionary.AllKeys)
            {
                if (calculateString.Contains(key))
                {
                    RemoveCharsInWindow(key);
                    WriteAllSymbols();
                    RemoveCharsInWindow(ref window, window.Length);
                    WriteSymbol(HtmlCodes.Dictionary[key]);
                    break;
                }
            }
        }

        public void MoveWindow()
        {
            for (int i = 0; i < window.Length - 1; i++)
                window[i] = window[i + 1];
        }

        public void SetLastCharacter(string character)
        {
            window[window.Length - 1] = character;
        }

        public void WriteFirstSymbol()
        {
            WriteSymbol(window[0]);
        }
        public void WriteAllSymbols()
        {
            foreach (var element in window)
            {
                WriteSymbol(element);
            }
        }
    }
}
