// See https://aka.ms/new-console-template for more information
using Lab4_1;

StreamHandler sh = new StreamHandler(Console.In, Console.Out);
try
{
    sh.Start();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}