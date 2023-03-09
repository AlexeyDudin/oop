using System;

namespace Lab1_2
{
    public class Converter
    {
        private int _sourceNotation, _targetNotation;
        private char[] valuesArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public Converter(int sourceNotation, int targetNotation)
        {
            _sourceNotation = sourceNotation;
            _targetNotation = targetNotation;
        }

        private int GetIntegerFromValue(char value)
        {
            for (int i = 0; i < valuesArray.Length; i++)
            {
                if (valuesArray[i] == value)
                    return i;
            }
            return -1;
        }

        public string Convert(string value)
        {
            uint positiveIntegerValue;
            int integerValue = ConvertToInteger(value);
            positiveIntegerValue = (integerValue < 0) ? ConvertToUnsigned(integerValue) : (uint)integerValue;
            return ConvertToString(integerValue);
        }

        private uint ConvertToUnsigned(int integerValue)
        {
            return (uint)(UInt32.MaxValue + integerValue);
        }

        private string ConvertToString(int decimalValue)
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
                result = valuesArray[changedIntegerValue % _targetNotation] + result;
                changedIntegerValue = changedIntegerValue / _targetNotation;
            }
            return result;
        }

        private int ConvertToInteger(string value)
        {
            CheckValue(value);
            long result = 0;
            bool isNegative = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '-')
                {
                    isNegative = true;
                    continue;
                }
                int currentStepValue = GetIntegerFromValue(value[i]);
                CheckBounds(result, currentStepValue, isNegative);
                result += result * 10 + currentStepValue;
            }
            if (isNegative)
                result = - result;
            return (int)result;
        }

        private void CheckBounds(long result, int currentStepValue, bool isNegative)
        {
            throw new NotImplementedException();
        }

        private void CheckValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Получена пустая строка");
            if (value.Contains("-") && value[0] != '-')
                throw new ArgumentException("Введено не валидное значение");
            foreach (var character in value)
            {
                if (character == '-')
                    continue;
                if (GetIntegerFromValue(character) > _sourceNotation)
                    throw new ArgumentException("Выход за пределы исходной системы счисления");
            }
        }
    }
}
