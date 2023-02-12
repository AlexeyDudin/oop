namespace Lab1_2
{
    //Битовое представление ошибок
    public enum ResultEnums
    {
        Ok = 0,
        GetHelp = 0b1,
        CommandLine = 0b10,
        ErrorConvertToIntException = 0b100,
        NotationOutOfRangeException = 0b1000,
        ValueOutOfRangeException = 0b10000,
        NotSupportedValueCharacter = 0b100000,
    }
}
