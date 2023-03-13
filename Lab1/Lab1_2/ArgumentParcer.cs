using System;

namespace Lab1_2
{
    public class ArgumentParcer
    {
        public int SourceNotation { get; set; }
        public int DestinationNotation { get; set; }

        public string Value { get; set; }

        private static void PrintHelp()
        {
            Console.WriteLine("Lab1_2.exe <source notation> <destination notation> <value>");
        }

        private static bool CanConvertParamToInt(string param)
        {
            try
            {
                Int32.Parse(param);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private ResultEnums CheckParam(string[] args)
        {
            if (args.Length == 1 && (args[0].ToLower() == "-h" || args[0] == "/?"))
            {
                PrintHelp();
                return ResultEnums.GetHelp;
            }
            if (args.Length != 3)
            {
                Console.WriteLine("Ошибка параметров командной строки");
                PrintHelp();
                return ResultEnums.CommandLine;
            }

            if (!CanConvertParamToInt(args[0]))
            {
                Console.WriteLine($"Ошибка конвертирования первого параметра командной строки в integer");
                return (ResultEnums.ErrorConvertToIntException | ResultEnums.CommandLine);
            }

            if (!CanConvertParamToInt(args[1]))
            {
                Console.WriteLine($"Ошибка конвертирования второго параметра командной строки в integer");
                return (ResultEnums.ErrorConvertToIntException | ResultEnums.CommandLine);
            }

            if (Int32.Parse(args[0]) <= 1 || Int32.Parse(args[0]) >= 37)
            {
                Console.WriteLine($"Поддерживаемые диапазоны системы счислений с 2 по 36. Ошибка в первом параметре. Задано значение: {args[0]}");
                return (ResultEnums.NotationOutOfRangeException | ResultEnums.CommandLine);
            }

            if (Int32.Parse(args[1]) <= 1 || Int32.Parse(args[1]) >= 37)
            {
                Console.WriteLine($"Поддерживаемые диапазоны системы счислений с 2 по 36. Ошибка во втором параметре. Задано значение: {args[1]}");
                return (ResultEnums.NotationOutOfRangeException | ResultEnums.CommandLine);
            }

            return ResultEnums.Ok; //CheckValueOnNotationException(args[0], args[2]);
        }

        public ArgumentParcer(string[] args) 
        {
            var resultCheckParam = CheckParam(args);
            if (resultCheckParam == ResultEnums.Ok)
            {
                this.SourceNotation = Int32.Parse(args[0]);
                this.DestinationNotation = Int32.Parse(args[1]);
                this.Value = args[2];
            }
            else
                throw new ArgumentException("Ошибка в параметрах командной строки", resultCheckParam.ToString());
        }
    }
}
