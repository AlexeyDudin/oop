namespace Lab5_1
{
    public interface ICalendar
    {
        public ushort GetDay();
        public Month GetMonth();
        public ushort GetYear();
        public WeekDay GetWeekDay();
    }
}
