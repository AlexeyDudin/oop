using Lab3_1;

CommandWorker cw = new ();
Console.WriteLine("Введите команду: ");
try
{
    cw.Work(Console.In, Console.Out);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
