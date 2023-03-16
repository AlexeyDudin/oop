using Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab2_4
{
    public static class DictionaryWorker
    {
        private static void FillEratosphen(HashSet<int> dictionary)
        {
            for (int i = 2; i < dictionary.Count; i++)
            {
                RemoveValuesFromSet(dictionary, i);
            }
        }

        private static void RemoveValuesFromSet(HashSet<int> dictionary, int i)
        {
            int multiplyer = 2;
            while (multiplyer * i < (uint)dictionary.Count)
            {
                dictionary.Remove(multiplyer * i);
                multiplyer++;
            }
        }

        public static HashSet<int> GeneratePrimeNumbersSet(int upperBound)
        {
            HashSet<int> result = FillDictionary(upperBound);
            FillEratosphen(result);
            return result;
        }

        private static HashSet<int> FillDictionary(int upperBound)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 1; i < upperBound; i++)
            {
                result.Add(i);
            }
            return result;
        }

        public static void Write(HashSet<int> result)
        {
            foreach (var elem in result)
            {
                Console.WriteLine($"{elem}");
            }
        }
    }
}
