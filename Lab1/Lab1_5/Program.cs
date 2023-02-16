using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1_5
{
    public class Program
    {
        private static StatusEnums CheckArgs(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Ошибка в аргументах командной строки");
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

            Field field = new Field();
            try
            {
                field.FieldPole = Field.FillFieldFromFile(args[0]);
                field.FillField();
                Field.SaveFiledToFile(field, args[1]);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Ошибка при чтении файла {args[0]}\n{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)StatusEnums.WorkWithFileError;
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine($"Ошибка при выделении памяти\n{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)StatusEnums.OutOfMemoryError;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при работе с файлом\n{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)StatusEnums.WorkWithFileError;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{string.Join("<-", e.Data)}");
                return (int)StatusEnums.OtherExceptions;
            }

            return (int)StatusEnums.Ok;
        }
    }
}
