using System;
using System.Collections.Generic;
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

        public void Run(Dictionary library) 
        {
            while (true)
            {
                PrintUserInputSymbol(_textWriter);
                string userWord = _textReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(userWord))
                {
                    //Зачем поля этого класса передавать внутрь себя?
                    if (IsExit(userWord, _textReader, _textWriter, library))
                        break;

                    var findWords = library.FindWord(userWord);

                    if (findWords.Count == 0)
                    {
                        AddWord(userWord, _textWriter, _textReader, library);
                    }
                    else
                    {
                        PrintFindWord(userWord, findWords, _textWriter);
                    }
                }
            }
        }

        private void PrintFindWord(string userWord, System.Collections.Generic.List<Word> findWords, TextWriter textWriter)
        {
            foreach (var findWord in findWords)
            {
                if (findWord.FirstWord.ToUpper() == userWord.ToUpper())
                {
                    List<string> translateWords = new List<string>();
                    foreach (var translateFindWord in findWords)
                    {
                        translateWords.Add(translateFindWord.SecondWord);
                    }
                    _textWriter.WriteLine(string.Join(", ", translateWords));
                    break;
                }
                else if (findWord.SecondWord.ToUpper() == userWord.ToUpper())
                {
                    List<string> translateWords = new List<string>();
                    foreach (var translateFindWord in findWords)
                    {
                        translateWords.Add(translateFindWord.FirstWord);
                    }
                    _textWriter.WriteLine(string.Join(", ", translateWords));
                    break;
                }
                //_textWriter.WriteLine((findWords.FirstWord == userWord) ? findWords.SecondWord : findWords.FirstWord);
            }
        }

        private void AddWord(string userWord, TextWriter textWriter, TextReader textReader, Dictionary library)
        {
            _textWriter.WriteLine($"Неизвестное слово \"{userWord}\". Введите перевод или пустую строку для отказа.");
            PrintUserInputSymbol(_textWriter);
            string translateWord = _textReader.ReadLine();

            if (!string.IsNullOrWhiteSpace(translateWord))
            {
                string[] words = translateWord.Split(',');
                foreach (var textWord in words)
                {
                    Word word = new Word()
                    {
                        FirstWord = userWord,
                        SecondWord = textWord.Trim()
                    };

                    library.AddWord(word);

                    _textWriter.WriteLine($"Слово \"{word.FirstWord}\" сохранено в словаре как \"{word.SecondWord}\".");
                }
            }
            else
            {
                _textWriter.WriteLine($"Слово \"{userWord}\" проигнорировано.");
            }
        }

        private bool IsExit(string userWord, TextReader textReader, TextWriter textWriter, Dictionary library)
        {
            if (userWord == EXIT_STRING)
            {
                if (library.HasNewWords())
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
