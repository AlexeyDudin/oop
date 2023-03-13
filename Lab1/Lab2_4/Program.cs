using System;
using System.Collections.Generic;

namespace Lab2_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, bool> result = DictionaryWorker.GeneratePrimeNumbersSet(Int32.Parse(Console.ReadLine()));
            DictionaryWorker.Write(result);
            Console.ReadKey();
        }
    }
}
