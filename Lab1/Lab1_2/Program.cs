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
                int decimalValueOfChar = GetDecimalValueOf(value[i]);
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

        private static int GetDecimalValueOf(char character)
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

        private static int ConvertToDecimal(string inputValue, int sourceNotation)
        {
            int result = 0;
            bool isValueNegative = false;
            bool isNeedMultiplyOnMinus = false;
            for (int i = 0; i < inputValue.Length; i++)
            {
                if (inputValue[i] != '-')
                {
                    int calculatedIterationValue = GetDecimalValueOf(inputValue[i]) * (int)Math.Pow(sourceNotation, inputValue.Length - 1 - i);
                    if (calculatedIterationValue < 0)
                        isValueNegative = true;

                    //TODO выход за диапазон Int32
                    if (isValueNegative)
                    {
                        if (Int32.MinValue - result > calculatedIterationValue)
                            throw new ArgumentOutOfRangeException($"Ошибка! Превышено значение Int32 {Int32.MinValue}");
                    }
                    else
                    {
                        if ((Int32.MaxValue - result) < calculatedIterationValue)
                            throw new ArgumentOutOfRangeException($"Ошибка! Превышено значение Int32 {Int32.MaxValue}");
                    }

                    if (isNeedMultiplyOnMinus)
                        result -= calculatedIterationValue;
                    else
                        result += calculatedIterationValue;
                }
                else
                {
                    isValueNegative = true;
                    isNeedMultiplyOnMinus = true;
                }
            }
            return result;
        }

        private static string ConvertToDestinationNotation(int decimalValue, int destinationNotation)
        {
            string result = "";
            long changedDecimalValue = decimalValue;
            bool isValueNegative = false;
            if (changedDecimalValue < 0)
            {
                isValueNegative = true;
                changedDecimalValue = UInt32.MaxValue + changedDecimalValue + 1;
            }
            if (changedDecimalValue == 0)
                return "0";
            while (changedDecimalValue != 0)
            {
                if (isValueNegative)
                {
                    var temporary = (changedDecimalValue) % destinationNotation;
                    if (temporary < 0)
                        temporary = destinationNotation + temporary;
                    result = valuesArray[temporary] + result;
                }
                else
                    result = valuesArray[changedDecimalValue % destinationNotation] + result;
                changedDecimalValue = changedDecimalValue / destinationNotation;
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

                int decimalValue = ConvertToDecimal(inputValue, Int32.Parse(args[0]));
                string resultValue = ConvertToDestinationNotation(decimalValue, Int32.Parse(args[1]));
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
