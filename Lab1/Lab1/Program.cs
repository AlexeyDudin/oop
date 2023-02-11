using System;
using System.IO;

namespace Lab1
{
    public  class Program
    {
        public static void PrintHelp()
        {
            Console.WriteLine("Lab1_1.exe <input file> <output file> <search string> <replace string>");
        }
        public static int Main(string[] args)
        {
            if (args.Length == 1 && (args[0].ToLower() == "-h" || args[0] == "/?"))
            {
                PrintHelp();
                return (int)ErrorEnums.None;
            }
            if (args.Length != 4)
            {
                Console.WriteLine("Ошибка параметров командной строки!");
                PrintHelp();
                return (int)ErrorEnums.CommandLine;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Файл {args[0]} не существует");
                return (int)ErrorEnums.ReadFile;
            }

            //Удаляем выходной файл, если он существует
            if (File.Exists(args[1]))
            {
                File.Delete(args[1]);
            }

            //Переменная для отслеживания, была ли найдена хотя-бы одна искомая строка
            bool isFoundSearchedString = false;

            try
            {
                //Открываем файлы через файловые потоки
                FileStream inputFileStream = File.OpenRead(args[0]);
                FileStream outputFileStream = File.OpenWrite(args[1]);

                //Считыватель и запись из/в файловые потоки
                StreamReader streamReader = new StreamReader(inputFileStream);
                StreamWriter streamWriter = new StreamWriter(outputFileStream);

                string readedString;
                //Пока можем считать из файла строку
                while ((readedString = streamReader.ReadLine()) != null)
                {
                    string recievedString;
                    if (readedString.Contains(args[2]))
                    {
                        isFoundSearchedString = true;
                        recievedString = readedString.Replace(args[2], args[3]);
                    }
                    else
                        recievedString = readedString;
                    streamWriter.WriteLine(recievedString);
                }

                //Закрываем управление потоками
                streamReader.Close();
                streamWriter.Close();
                inputFileStream.Close();
                outputFileStream.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return (int)ErrorEnums.InputOutputExceptions;
            }

            //Было ли вхождение хоть одной искомой строки
            if (!isFoundSearchedString)
            {
                Console.WriteLine("Не найдена ни одна искомая строка");
                return (int)ErrorEnums.NoSearchString;
            }

            return (int)ErrorEnums.None;
        }
    }
}
