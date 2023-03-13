using System;
using System.IO;

namespace Lab1_4
{
    public class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("Lab1_4.exe pack/unpack <source file> <destination file>");
        }

        private static ResultEnums CheckParams(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Ошибка параметров командной строки");
                PrintHelp();
                return ResultEnums.ArgumentException;
            }

            if (args[0] != "pack" && args[0] != "unpack")
            {
                Console.WriteLine($"Ошибка параметров командной строки! Параметр {args[0]} не расопознан");
                return ResultEnums.ArgumentException;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine($"Ошибка параметров командной строки! Файл {args[1]} не найден");
                return ResultEnums.ArgumentException | ResultEnums.WorkWithFileError;
            }

            return ResultEnums.Ok;
        }

       
        public static int Main(string[] args)
        {
            // переделать в параметры -> CheckParams ParceParams
            // >255 = 255 byte + x byte
            ResultEnums resultCheckParam = CheckParams(args);
            if (resultCheckParam != ResultEnums.Ok)
                return (int)resultCheckParam;

            try
            {
                if (File.Exists(args[2]))
                    File.Delete(args[2]);

                switch (args[0])
                {
                    case "pack":
                        Compressor.Compress(args[1], args[2]);
                        break;
                    case "unpack":
                        Compressor.UnCompress(args[1], args[2]);
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                //Сделать исключения проще
                Console.WriteLine(e.Message);
                try
                {
                    File.Delete(args[1]);
                }
                catch
                {
                    Console.WriteLine($"Ошибка удаления файла {args[1]}");
                }
                return (int)ResultEnums.WorkWithFileError;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при работе с файлом\n{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)ResultEnums.WorkWithFileError;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)ResultEnums.OtherExceptions;
            }

            return (int)ResultEnums.Ok;
        }
    }
}
