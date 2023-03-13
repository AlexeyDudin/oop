using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab2_3
{
    public class Library
    {
        private string libraryFileName = "";
        private List<Word> words;
        private bool haveNewWord = false;

        public void LoadLibrary(string fileName)
        {
            libraryFileName = fileName;
            try
            {
                string readJson = File.ReadAllText(fileName);
            
                words = JsonSerializer.Deserialize<List<Word>>(readJson);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка чтения файла библиотеки\n{ex.Message}");
                words = new List<Word>();
            }
        }

        public bool IsHaveNewWord()
        { 
            return haveNewWord; 
        }

        public void SaveLibrary()
        {
            var fileStream = File.Create(libraryFileName);
            JsonSerializer.Serialize(fileStream, words);
            fileStream.Close();
        }

        public Word FindWord(string value)
        {
            string modifyValue = value.ToUpper();
            return words.Where(w => w.FirstWord.ToUpper() == modifyValue || w.SecondWord.ToUpper() == modifyValue).FirstOrDefault();
        }

        public void AddWord(Word word) 
        {
            words.Add(word);
            haveNewWord = true;
        }
    }
}
