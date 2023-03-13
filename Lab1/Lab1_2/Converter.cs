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

        private char GetCharFromInteger(int position)
        {
            return valuesArray[position];
        }

        public string Convert(string value)
        {
            CheckValue(value);
            string convertValue = value;
            if (IsValueNegative(value))
                convertValue = ConvertToUnsigned(convertValue);
            uint integerValue = ConvertToInteger(convertValue);
            convertValue = ConvertToString(integerValue, _targetNotation);
            if (IsValueNegative(value))
                convertValue = "-" + ConvertToSigned(convertValue);
            return convertValue;
        }

        private bool IsValueNegative(string convertValue)
        {
            return convertValue[0] == '-';
        }

        private string ConvertToSigned(string convertValue)
        {
            string result = "";
            string maxSignedIntStringValue = ConvertToString(UInt32.MaxValue, _targetNotation);
            maxSignedIntStringValue = ExpandValue(maxSignedIntStringValue, convertValue.Length);

            result = Decrement(convertValue, ExpandValue("1", convertValue.Length), _targetNotation);
            result = Decrement(maxSignedIntStringValue, result, _targetNotation);

            return result;
        }

        private string ConvertToUnsigned(string value)
        {
            string result = "";
            string maxUnsignedIntStringValue = ConvertToString(UInt32.MaxValue, _sourceNotation);

            string expandValue = RemoveMinus(value);
            expandValue = ExpandValue(expandValue, maxUnsignedIntStringValue.Length);

            expandValue = Decrement(expandValue, ExpandValue("1", maxUnsignedIntStringValue.Length), _sourceNotation);

            result = Decrement(maxUnsignedIntStringValue, expandValue, _sourceNotation);
            
            return result;
        }

        private string Increment(string from, string count, int notation)
        {
            string result = "";

            bool isBorrowValue = false;
            for (int i = from.Length - 1; i >= 0; i--)
            {
                int charIntegerUnsignedString = GetIntegerFromValue(from[i]);
                if (isBorrowValue)
                    charIntegerUnsignedString++;
                int charIntegerExpand = GetIntegerFromValue(count[i]);
                int newValue = charIntegerUnsignedString + charIntegerExpand;
                if (newValue >= notation)
                {
                    newValue -= notation;
                    isBorrowValue = true;
                }
                else
                    isBorrowValue = false;

                result = GetCharFromInteger(newValue) + result;
            }

            return result;
        }
        private string Decrement(string from, string count, int notation)
        {
            string result = "";

            bool isBorrowValue = false;
            for (int i = from.Length - 1; i >= 0; i--)
            {
                int charIntegerUnsignedString = GetIntegerFromValue(from[i]);
                if (isBorrowValue)
                    charIntegerUnsignedString--;
                int charIntegerExpand = GetIntegerFromValue(count[i]);

                int newValue = charIntegerUnsignedString - charIntegerExpand;
                if (newValue < 0)
                {
                    isBorrowValue = true;
                    newValue += notation;
                }
                else
                    isBorrowValue = false;

                result = GetCharFromInteger(newValue) + result;
            }

            return result;
        }

        private string RemoveMinus(string value)
        {
            return value.Replace("-", "");
        }

        private string ExpandValue(string value, int countOfDigits)
        {
            string result = value;
            while (result.Length < countOfDigits)
            {
                result = "0" + result;
            }
            return result;
        }

        private string ConvertToString(uint integerValue, int targetNotation)
        {
            string result = "";
            uint changedIntegerValue = integerValue;
            if (changedIntegerValue == 0)
                return "0";
            while (changedIntegerValue != 0)
            {
                result = GetCharFromInteger((int)(changedIntegerValue % targetNotation)) + result;
                changedIntegerValue = (uint)(changedIntegerValue / targetNotation);
            }
            return result;
        }

        private uint ConvertToInteger(string value)
        {
            uint result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                int integerValue = GetIntegerFromValue(value[i]);
                if (integerValue < 0)
                    throw new ArgumentOutOfRangeException($"Не удалось найти символ {value[i]}");
                result = result * 10 + (uint)integerValue;
            }
            return result;
        }

        private void CheckValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
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
