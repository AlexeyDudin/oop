using Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab2_4
{
    public static class DictionaryWorker
    {
        private static HashSet<int> FillEratosphen(int upperBound)
        {
            HashSet<int> result = new HashSet<int>();
            List<bool> bools = new List<bool>(Enumerable.Repeat(true, upperBound + 1));

            for (int i = 2; i < bools.Count; i++)
            {
                if (bools[i])
                    RemoveValuesFromSet(bools, i);
            }

            for (int i = 0; i < bools.Count; i++)
            {
                if (bools[i])
                    result.Add(i);
            }

            return result;
        }

        private static void RemoveValuesFromSet(List<bool> bools, int i)
        {
            int multiplyer = 2;
            while (multiplyer * i < (uint)bools.Count())
            {
                bools[multiplyer * i] = false;
                multiplyer++;
            }
        }

        public static HashSet<int> GeneratePrimeNumbersSet(int upperBound)
        {
            return FillEratosphen(upperBound);
        }

        public static void Write(HashSet<int> result)
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
