namespace Lab1_5
{
    public enum StatusEnums
    {
        Ok = 0,
        WorkWithFileError = 0b1,
        ArgumentError = 0b10,
        OutOfMemoryError = 0b100,
        OtherExceptions = 0b1000
    }
}
