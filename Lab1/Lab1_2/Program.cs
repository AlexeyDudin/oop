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
                    return ResultEnums.CommandLine | ResultEnums.NotationOutOfRangeException;
            }
            return ResultEnums.None;
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

            return CheckValueOnNotationException(args[0], args[2]);
        }

        private static int GetDecimalValueOf(char character)
        {
            for (int i = 0; i < valuesArray.Length; i++)
            {
                if (character == valuesArray[i])
                    return i;
            }
            throw new ArgumentOutOfRangeException($"Ошибка параметров командной строки! Символ {character} не поддерживается!");
        }

        private static int ConvertToDecimal(string inputValue, int sourceNotation)
        {
            int result = 0;
            for (int i = 0; i < inputValue.Length; i++)
            {
                int calculatedIterationValue = GetDecimalValueOf(inputValue[i]) * (int)Math.Pow(sourceNotation, inputValue.Length - 1 - i);
                if ((Int32.MaxValue - result) < calculatedIterationValue)
                    throw new ArgumentOutOfRangeException($"Ошибка! Превышено значение Int32 {Int32.MaxValue}");
                result += calculatedIterationValue;
            }
            return result;
        }

        private static string ConvertToDestinationNotation(int decimalValue, int destinationNotation)
        {
            string result = "";
            int changedDecimalvalue = decimalValue;
            while (changedDecimalvalue != 0)
            {
                result = valuesArray[(changedDecimalvalue % destinationNotation)] + result;
                changedDecimalvalue = changedDecimalvalue / destinationNotation;
            }
            return result;
        }

        //radix 
        public static int Main(string[] args)
        {
            try
            {
                ResultEnums resultCheckParam = CheckParam(args);

                if (resultCheckParam != ResultEnums.None)
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

            return (int)ResultEnums.None;
        }
    }
}
