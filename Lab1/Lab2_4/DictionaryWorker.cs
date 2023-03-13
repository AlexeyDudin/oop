using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab2_4
{
    public static class DictionaryWorker
    {
        private static void FillEratosphen(Dictionary<int, bool> dictionary)
        {
            for (int i = 2; i < dictionary.Count; i++)
            {
                if (dictionary[i])
                    SetValuesDisable(dictionary, i);
            }
        }

        private static void SetValuesDisable(Dictionary<int, bool> dictionary, int i)
        {
            int multiplyer = 2;
            while (multiplyer * i < (uint)dictionary.Count)
            {
                dictionary[multiplyer * i] = false;
                multiplyer++;
            }
        }

        public static Dictionary<int, bool> GeneratePrimeNumbersSet(int upperBound)
        {
            Dictionary<int, bool> result = FillDictionary(upperBound);
            FillEratosphen(result);
            return result;
        }

        private static Dictionary<int, bool> FillDictionary(int upperBound)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            for (int i = 1; i < upperBound; i++)
            {
                result.Add(i, true);
            }
            return result;
        }

        public static void Write(Dictionary<int, bool> result)
        {
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i])
                    Console.Write($"{i} ");
            }
        }
    }
}
