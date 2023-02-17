namespace Lab1_3
{
    public enum ResultEnums
    {
        Ok = 0,
        FileNotFound = 0b1,
        ArgumentException = 0b10,
        BadFileFormat = 0b100,
        FileWorkException = 0b1000
    }
}
