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

        public static ErrorEnums FileWorking(string[] args)
        {
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
                    if (readedString.Contains(args[2]) && !string.IsNullOrEmpty(args[2]))
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
                return ErrorEnums.InputOutputExceptions;
            }

            //Было ли вхождение хоть одной искомой строки
            if (!isFoundSearchedString)
            {
                Console.WriteLine("Не найдена ни одна искомая строка");
                return ErrorEnums.NoSearchString;
            }

            return ErrorEnums.Ok;
        }

        public static ErrorEnums CheckParams(string[] args)
        {
            if (args.Length == 1 && (args[0].ToLower() == "-h" || args[0] == "/?"))
            {
                PrintHelp();
                return ErrorEnums.Ok;
            }
            if (args.Length != 4)
            {
                Console.WriteLine("Ошибка параметров командной строки!");
                PrintHelp();
                return ErrorEnums.CommandLine;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Файл {args[0]} не существует");
                return ErrorEnums.ReadFile;
            }
            return ErrorEnums.Ok;
        }

        public static int Main(string[] args)
        {
            ErrorEnums resultCheckParam = CheckParams(args);
            if (resultCheckParam != ErrorEnums.Ok)
                return (int)resultCheckParam;

            return (int)FileWorking(args);
        }
    }
}
