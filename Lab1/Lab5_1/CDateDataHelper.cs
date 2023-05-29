using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_1
{
    public static class CDateDataHelper
    {
        public static readonly Dictionary<YearType, ulong> TypeYear = new Dictionary<YearType, ulong>() { { YearType.NOT_LEAP, 365 }, { YearType.LEAP, 366 } };
        public static readonly Dictionary<Month, ulong> DayInMonth = new Dictionary<Month, ulong>()
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
        public const ushort StartYear = 1970;
        public const ushort LastYear = 9999;
        public const ulong MaxTimeStamp = 2932897;
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
