using Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab2_4
{
    public static class DictionaryWorker
    {
        private static void FillEratosphen(HashSet<Element> dictionary)
        {
            for (int i = 2; i < dictionary.Count; i++)
            {
                RemoveValuesFromSet(dictionary, i);
            }
        }

        private static void RemoveValuesFromSet(HashSet<Element> dictionary, int i)
        {
            int multiplyer = 2;
            while (multiplyer * i < (uint)dictionary.Count())
            {
                dictionary.ElementAt(multiplyer * i).IsActive = false;
                multiplyer++;
            }
        }

        public static HashSet<Element> GeneratePrimeNumbersSet(int upperBound)
        {
            HashSet<Element> result = FillDictionary(upperBound);
            FillEratosphen(result);
            return result;
        }

        private static HashSet<Element> FillDictionary(int upperBound)
        {
            HashSet<Element> result = new HashSet<Element>();
            for (int i = 1; i < upperBound; i++)
            {
                result.Add(new Element() { Number = i, IsActive = true });
            }
            return result;
        }

        public static void Write(HashSet<Element> result)
        {
            foreach (var elem in result)
            {
                if (elem.IsActive)
                    Console.WriteLine($"{elem}");
            }
        }
    }
}
