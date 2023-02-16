namespace Lab1
{
    //Битовое представление ошибок
    //00000000
    //00000001 - Ошибка параметров командной строки
    //00000010 - Ошибка чтения файла
    //00000100 - Ошибка записи в файл
    public enum ErrorEnums
    {
        Ok = 0,
        CommandLine = 0b1,
        ReadFile = 0b10,
        WriteFile = 0b100,
        NoSearchString = 0x1000,
        InputOutputExceptions = 0x10000
    }
}
