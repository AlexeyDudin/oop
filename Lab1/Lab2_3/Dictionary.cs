using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab2_3
{
    //Допереименовать
    //HashMap или SortMap
    //Обработка ошибок загруки - другой класс
    public class Dictionary
    {
        private string libraryFileName = "";
        private HashSet<Word> words;
        private bool haveNewWord = false;

        public void LoadLibrary(string fileName)
        {
            libraryFileName = fileName;
            try
            {
                string readJson = File.ReadAllText(fileName);
            
                words = JsonSerializer.Deserialize<HashSet<Word>>(readJson);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка чтения файла библиотеки\n{ex.Message}");
                words = new HashSet<Word>();
            }
        }

        public bool HasNewWords()
        { 
            return haveNewWord; 
        }

        //Лучше не знать как себя сохранять
        public void SaveLibrary()
        {
            var fileStream = File.Create(libraryFileName);
            JsonSerializer.Serialize(fileStream, words);
            fileStream.Close();
        }

        public List<Word> FindWord(string value)
        {
            string modifyValue = value.ToUpper();
            return words.Where(w => w.FirstWord.ToUpper() == modifyValue || w.SecondWord.ToUpper() == modifyValue).ToList();
        }

        //А что будет, если слово уже есть
        public void AddWord(Word word) 
        {
            words.Add(word);
            haveNewWord = true;
        }
    }
}
