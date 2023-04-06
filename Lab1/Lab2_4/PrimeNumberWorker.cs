using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab2_4
{
    public static class PrimeNumberWorker
    {
        private static SortedSet<int> FillEratosphen(int upperBound)
        {
            SortedSet<int> result = new SortedSet<int>();
            //Решето, а не bools
            List<bool> bools = new List<bool>(Enumerable.Repeat(true, upperBound + 1));

            for (int i = 2; i < bools.Count; i++)
            {
                if (bools[i])
                    SetNonActiveValuesInVector(bools, i);
            }

            for (int i = 0; i < bools.Count; i++)
            {
                if (bools[i])
                    result.Add(i);
            }

            return result;
        }

        //Переименовать функцию и наименование bools
        //Возможно надо начать с квадрата и идти с шагом 
        //Поискать способы ускорения
        private static void SetNonActiveValuesInVector(List<bool> bools, int i)
        {
            //
            int multiplyer = 2;
            while (multiplyer * i < (uint)bools.Count())
            {
                bools[multiplyer * i] = false;
                multiplyer++;
            }
        }

        public static SortedSet<int> GeneratePrimeNumbersSet(int upperBound)
        {
            var startDateTime = DateTime.Now;
            var result = FillEratosphen(upperBound);
            var endDateTime = DateTime.Now;
            //Убрать вывод
            Console.WriteLine($"{(endDateTime - startDateTime).TotalMilliseconds} ms.");
            return result;
        }

        public static void Write(SortedSet<int> result, TextWriter outputStream)
        {
            //Сделать вывод вручную
            outputStream.WriteLine(string.Join(", ", result));
        }
    }
}
