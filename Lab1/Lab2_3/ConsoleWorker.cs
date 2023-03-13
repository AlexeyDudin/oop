using System;
using System.IO;

namespace Lab2_3
{
    public class ConsoleWorker
    {
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;
        private const string EXIT_STRING = "...";

        public ConsoleWorker(TextReader textReader, TextWriter textWriter)
        {
            _textReader = textReader;
            _textWriter = textWriter;
        }

        private void PrintUserInputSymbol(TextWriter _textWriter)
        {
            _textWriter.Write(">");
        }

        public void Run(Library library) 
        {
            while (true)
            {
                PrintUserInputSymbol(_textWriter);
                string userWord = _textReader.ReadLine();

                if (IsExit(userWord, _textReader, _textWriter, library))
                    break;
                
                Word findWord = library.FindWord(userWord);

                if (findWord == null)
                {
                    AddWord(userWord, _textWriter, _textReader, library);
                }
                else
                {
                    PrintFindWord(userWord, findWord, _textWriter);
                }
            }
        }

        private void PrintFindWord(string userWord, Word findWord, TextWriter textWriter)
        {
            _textWriter.WriteLine((findWord.FirstWord == userWord) ? findWord.SecondWord : findWord.FirstWord); ;
        }

        private void AddWord(string userWord, TextWriter textWriter, TextReader textReader, Library library)
        {
            _textWriter.WriteLine($"Неизвестное слово \"{userWord}\". Введите перевод или пустую строку для отказа.");
            PrintUserInputSymbol(_textWriter);
            string translateWord = _textReader.ReadLine();

            if (!string.IsNullOrWhiteSpace(translateWord))
            {
                Word word = new Word()
                {
                    FirstWord = userWord,
                    SecondWord = translateWord
                };

                library.AddWord(word);
                
                _textWriter.WriteLine($"Слово \"{word.FirstWord}\" сохранено в словаре как \"{word.SecondWord}\".");
            }
            else
            {
                _textWriter.WriteLine($"Слово \"{userWord}\" проигнорировано.");
            }
        }

        private bool IsExit(string userWord, TextReader textReader, TextWriter textWriter, Library library)
        {
            if (userWord == EXIT_STRING)
            {
                if (library.IsHaveNewWord())
                {
                    _textWriter.WriteLine("В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.");
                    
                    string answer = _textReader.ReadLine();
                    if (answer == "Y" || answer == "y")
                        library.SaveLibrary();
                }
                return true;
            }
            return false;
        }
    }
}
