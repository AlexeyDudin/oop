using System;
using System.IO;
using System.Text;

namespace Lab2_2
{
    public class Window
    {
        private readonly TextWriter _textWriter;
        //попробовать другой способ
        private string[] window;

        public Window(TextWriter textWriter)
        {
            _textWriter = textWriter;
            int maxLength = GetMaxKeyLenght();
            window = new string[maxLength];
        }

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
        private void MoveWindow()
        {
            for (int i = 0; i < window.Length - 1; i++)
                window[i] = window[i + 1];
        }

        public void Parce()
        {
            var calculateString = GetString();
            foreach (var key in HtmlCodes.Dictionary.AllKeys)
            {
                if (calculateString.Contains(key))
                {
                    RemoveCharsInWindow(key);
                    WriteAllAvailableSymbols();
                    RemoveCharsInWindow(ref window, window.Length);
                    WriteSymbol(HtmlCodes.Dictionary[key]);
                    break;
                }
            }
        }

        public void Push(string character)
        {
            MoveWindow();
            window[window.Length - 1] = character;
        }

        public void WriteFirstSymbol()
        {
            WriteSymbol(window[0]);
        }
        public void WriteAllAvailableSymbols()
        {
            foreach (var element in window)
            {
                WriteSymbol(element);
            }
        }
    }
}
