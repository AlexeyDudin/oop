using System;

namespace Lab1_2
{
    public class Program
    {
       //radix 
        public static int Main(string[] args)
        {
            try
            {
                ArgumentParcer argumentParcer = new ArgumentParcer(args);

                string inputValue = argumentParcer.Value.ToUpper();

                Converter converter = new Converter(argumentParcer.SourceNotation, argumentParcer.DestinationNotation);
                Console.WriteLine(converter.Convert(inputValue));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)(ResultEnums.ValueOutOfRangeException | ResultEnums.CommandLine);
            }

            return (int)ResultEnums.Ok;
        }
    }
}
