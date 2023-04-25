// See https://aka.ms/new-console-template for more information
using Lab3_2;

try
{
    StreamHandler sh = new StreamHandler(Console.In, Console.Out);
    sh.Work();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}