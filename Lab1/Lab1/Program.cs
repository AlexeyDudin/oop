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

        public static ErrorEnums HandleFile(string inputFile, string outputFile, string stringToChange, string newString)
        {
            //Удаляем выходной файл, если он существует
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            //Переменная для отслеживания, была ли найдена хотя-бы одна искомая строка
            bool isFoundSearchedString = false;
            
            using (var inputFileStream = File.OpenRead(inputFile) )
            {
                using (var outputFileStream = File.OpenWrite(outputFile))
                {
                    //Считыватель и запись из/в файловые потоки
                    using (var streamReader = new StreamReader(inputFileStream))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(outputFileStream))
                        {
                            try
                            {
                                string readString;
                                //Пока можем считать из файла строку
                                while ((readString = streamReader.ReadLine()) != null)
                                {
                                    string recieveString;
                                    if (!string.IsNullOrEmpty(stringToChange) && readString.Contains(stringToChange))
                                    {
                                        isFoundSearchedString = true;
                                        recieveString = readString.Replace(stringToChange, newString);
                                    }
                                    else
                                        recieveString = readString;
                                    streamWriter.WriteLine(recieveString);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Ошибка при работе с файлом.\n{e.Message}");
                                return ErrorEnums.InputOutputExceptions;
                            }
                        }
                    }
                }
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

            return (int)HandleFile(args[0], args[1], args[2], args[3]);
        }
    }
}
