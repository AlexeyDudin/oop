using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1_5
{
    public class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("Lab1_5.exe <input file> <output file>");
        }
        private static StatusEnums CheckArgs(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Ошибка в аргументах командной строки");
                PrintHelp();
                return StatusEnums.ArgumentError;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Файл {args[0]} не существует");
                return StatusEnums.ArgumentError | StatusEnums.WorkWithFileError;
            }
            return StatusEnums.Ok;
        }

        public static int Main(string[] args)
        {
            StatusEnums result = CheckArgs(args);
            if (result != StatusEnums.Ok)
                return (int)result;

            FieldWorker worker = new FieldWorker();
            try
            {
                worker.Field = FieldWorker.LoadFieldFromFile(args[0]);
                worker.FillField();
                FieldWorker.SaveFieldToFile(worker, args[1]);
            }
            //уменьшить Exception
            //catch (FileLoadException e)
            //{
            //    Console.WriteLine($"Ошибка при чтении файла {args[0]}\n{e.Message}\n{string.Join("<-", e.Data)}");
            //    return (int)StatusEnums.WorkWithFileError;
            //}
            //catch (OutOfMemoryException e)
            //{
            //    Console.WriteLine($"Ошибка при выделении памяти\n{e.Message}\n{string.Join("<-", e.Data)}");
            //    return (int)StatusEnums.OutOfMemoryError;
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine($"Ошибка при работе с файлом\n{e.Message}\n{string.Join("<-", e.Data)}");
            //    return (int)StatusEnums.WorkWithFileError;
            //}
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)StatusEnums.OtherExceptions;
            }

            return (int)StatusEnums.Ok;
        }
    }
}
