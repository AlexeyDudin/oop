using System;

namespace Lab1_2
{
    public class Program
    {
        private static char[] valuesArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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

        private static ResultEnums CheckValueOnNotationException(string sourceNotation, string value)
        {
            int notationIntValue = Int32.Parse(sourceNotation);
            for (int i = 0; i < value.Length; i++)
            {
                int decimalValueOfChar = GetDigitValueOf(value[i]);
                if (decimalValueOfChar >= notationIntValue)
                {
                    Console.WriteLine($"Ошибка в параметре value. Превышен диапазон значений исходной нотации\n<source notation> = {sourceNotation}\n<value> = {value}");
                    return ResultEnums.CommandLine | ResultEnums.NotationOutOfRangeException;
                }
            }
            return ResultEnums.Ok;
        }

        private static ResultEnums CheckParam(string[] args)
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

            return CheckValueOnNotationException(args[0], args[2]);
        }

        private static int GetDigitValueOf(char character)
        {
            for (int i = 0; i < valuesArray.Length; i++)
            {
                if (character == valuesArray[i])
                    return i;
            }
            if (character == '-')
                return -1;
            throw new ArgumentOutOfRangeException($"Ошибка параметров командной строки! Символ {character} не поддерживается!");
        }


        private static int ConvertToInteger(string inputValue, int sourceNotation)
        {
            int result = 0;
            bool isValueNegative = false;
            foreach (char character in inputValue)
            {
                if (character != '-')
                {
                    if (isValueNegative)
                    {
                        if (Int32.MinValue - (result * 10) > GetDigitValueOf(character))
                            throw new ArgumentOutOfRangeException($"Ошибка! Превышено значение Int32 {Int32.MinValue}");
                        result = result * 10 - GetDigitValueOf(character);
                    }
                    else
                    {
                        if (Int32.MaxValue - (result * 10) < GetDigitValueOf(character))
                        {
                            throw new ArgumentOutOfRangeException($"Ошибка! Превышено значение Int32 {Int32.MinValue}");
                        }
                        result = result * 10 + GetDigitValueOf(character);
                    }
                }
                else
                {
                    isValueNegative = true;
                }
            }
            return result;
        }

        private static string ConvertToString(int decimalValue, int destinationNotation)
        {
            string result = "";
            long changedIntegerValue = decimalValue;
            if (decimalValue < 0)
            {
                changedIntegerValue = UInt32.MaxValue + changedIntegerValue + 1;
            }
            if (changedIntegerValue == 0)
                return "0";
            while (changedIntegerValue != 0)
            {
                result = valuesArray[changedIntegerValue % destinationNotation] + result;
                changedIntegerValue = changedIntegerValue / destinationNotation;
            }
            return result;
        }

        //radix 
        public static int Main(string[] args)
        {
            try
            {
                ResultEnums resultCheckParam = CheckParam(args);

                if (resultCheckParam != ResultEnums.Ok)
                    return (int)resultCheckParam;

                string inputValue = args[2].ToUpper();

                int decimalValue = ConvertToInteger(inputValue, Int32.Parse(args[0]));
                string resultValue = ConvertToString(decimalValue, Int32.Parse(args[1]));
                Console.WriteLine(resultValue);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return (int)(ResultEnums.ValueOutOfRangeException | ResultEnums.CommandLine);
            }

            return (int)ResultEnums.Ok;
        }
    }
}
