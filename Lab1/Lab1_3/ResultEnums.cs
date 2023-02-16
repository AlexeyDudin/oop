namespace Lab1_3
{
    public enum ResultEnums
    {
        Ok = 0,
        FileNotFound = 0b1,
        ArgumentException = 0b100,
        BadFileFormat = 0b1000,
        FileWorkException = 0b10000
    }
}
