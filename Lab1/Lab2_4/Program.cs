using System;
using System.Collections.Generic;

namespace Lab2_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputStream = Console.In;
                var outputStream = Console.Out;
                outputStream.Write("Введите значение максимального числа: ");
                var upperBound = Int32.Parse(inputStream.ReadLine());
                var result = PrimeNumberWorker.GeneratePrimeNumbersSet(upperBound);
                PrimeNumberWorker.Write(result, outputStream);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            finally 
            {
                Console.WriteLine("Для выхода нажмите любую клавишу");
                Console.ReadKey();
            }
        }
    }
}
