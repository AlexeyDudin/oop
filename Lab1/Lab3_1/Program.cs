using Lab3_1;

CommandHandler cw = new (Console.In, Console.Out);
try
{
    cw.Work();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
