namespace Lab5_1
{
    public class CDate
    {
        private readonly Dictionary<YearType, ulong> typeYear = new Dictionary<YearType, ulong>() { { YearType.NOT_LEAP, 365 }, { YearType.LEAP, 366 }};
        private readonly Dictionary<Month, ulong> dayInMonth = new Dictionary<Month, ulong>() 
        { 
            { Month.JANUARY, 31 }, 
            { Month.FEBRUARY, 28 },
            { Month.MARCH, 31 },
            { Month.APRIL, 30 },
            { Month.MAY, 31 },
            { Month.JUNE, 30 },
            { Month.JULY, 31 },
            { Month.AUGUST, 31 },
            { Month.SEPTEMBER, 30},
            { Month.OCTOBER, 31 },
            { Month.NOVEMBER, 30 },
            { Month.DECEMBER, 31 },
        };
        private const int startYear = 1970;
        private ulong _timestamp = 0;

        public CDate(ushort day, Month month, ushort year) 
        {
            if ((year < 1970) || (year > 9999))
                throw new ArgumentException($"Год {year} не в диапазоне 1970-9999");

        }

        public CDate(ulong timestamp)
        {
            _timestamp = timestamp;
        }

        public ushort GetDay()
        {
            throw new NotImplementedException();
        }

        public Month GetMonth()
        {
            throw new NotImplementedException();
        }

        public ushort GetYear()
        {
            ulong tempTimeStamp = _timestamp;
            ushort tempYear = startYear;
            while (tempTimeStamp > 0)
            {
                tempTimeStamp -= typeYear[GetYearType(tempYear)];
                if (tempTimeStamp > 0)
                    tempYear++;
            }
            return tempYear;
        }

        private YearType GetYearType(ushort year)
        {
            if (year % 4 != 0)
                return YearType.NOT_LEAP;
            if (year % 100 != 0)
                return YearType.LEAP;
            return (year % 400 == 0) ? YearType.LEAP: YearType.NOT_LEAP;
        }
    }

    public enum Month
    {
        JANUARY = 1, 
        FEBRUARY = 2,
        MARCH = 3,
        APRIL = 4,
        MAY = 5, 
        JUNE = 6, 
        JULY = 7,
        AUGUST = 8, 
        SEPTEMBER = 9,
        OCTOBER = 10,
        NOVEMBER = 11,
        DECEMBER = 12
    }

    public enum WeekDay
    {
        SUNDAY = 0,
        MONDAY = 1,
        TUESDAY = 2,
        WEDNESDAY = 3,
        THURSDAY = 4, 
        FRIDAY = 5,
        SATURDAY = 6
    }

    public enum YearType
    {
        NOT_LEAP,
        LEAP
    }
}
