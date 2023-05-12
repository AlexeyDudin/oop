using System.Text;

namespace Lab5_1
{
    public class CDate: ICalendar
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
        private const int lastYear = 9999;
        private const ulong maxTimeStamp = 2932897;
        private ulong _timestamp = 0;
        private bool isValid = true;

        public CDate(ushort day, Month month, ushort year) 
        {
            if ((year < startYear) || (year > lastYear))
            {
                isValid = false;
                return;
                //throw new ArgumentException($"Год {year} не в диапазоне 1970-9999");
            }
            if (day <= 0)
            {
                isValid = false;
                return;
                //throw new ArgumentException($"Дня под номером {day} не существует");
            }
            if (month != Month.FEBRUARY && day > dayInMonth[month])
            {
                isValid = false;
                return;
                //throw new ArgumentException($"Дня под номером {day} в месяце {month} {year} года не существует!");
            }
            else
            {
                if (GetYearType(year) == YearType.NOT_LEAP)
                {
                    if (day > dayInMonth[month])
                    {
                        isValid = false;
                        return;
                        //throw new ArgumentException($"Дня под номером {day} в месяце {month} {year} года не существует!");
                    }
                }
                else
                {
                    if (day > 29)
                    {
                        isValid = false;
                        return;
                        //throw new ArgumentException($"Дня под номером {day} в месяце {month} {year} года не существует!");
                    }
                }
            }
            _timestamp = (ulong)(day - 1) + GetDaysBeforeMonth(month, year) + GetDaysBeforeYear(year);
        }

        public CDate(ulong timestamp)
        {
            if (timestamp >= maxTimeStamp)
            {
                isValid = false;
                return;
            }
            _timestamp = timestamp;
        }

        public ulong GetTimeStamp() => _timestamp;

        public ushort GetDay()
        {
            return (ushort)(GetModOfMonth() + 1);
        }

        public Month GetMonth()
        {
            var tempDays = GetModOfYears();
            ulong subDays = 0;
            Month month = Month.JANUARY;
            ushort year = GetYear();
            while (tempDays > 0)
            {
                if (month == Month.FEBRUARY && GetYearType(year) == YearType.LEAP)
                    subDays = 29;
                else
                    subDays = dayInMonth[month];
                
                if (tempDays < subDays)
                    return month;
                tempDays -= subDays;
                month++;
            }
            return month;
        }

        public ushort GetYear()
        {
            ulong tempTimeStamp = _timestamp;
            ushort tempYear = startYear;
            while (tempTimeStamp > 0)
            {
                if (tempTimeStamp < typeYear[GetYearType(tempYear)])
                    break;
                tempTimeStamp -= typeYear[GetYearType(tempYear)];
                if (tempTimeStamp >= 0)
                    tempYear++;
            }
            return tempYear;
        }

        public WeekDay GetWeekDay()
        {
            var modOfDays = (_timestamp % 7) - 1;
            if (modOfDays < 0)
                modOfDays += 7;
            return (WeekDay)(((int)WeekDay.THURSDAY + modOfDays) % 7);
        }

        public bool IsValid()
        {
            return isValid;
        }

        public static CDate operator ++(CDate dateFirst)
        {
            return new CDate(dateFirst._timestamp + 1);
        }
        public static CDate operator +(CDate dateFirst, ulong days)
        {
            return new CDate(dateFirst._timestamp + days);
        }

        public static CDate operator --(CDate dateFirst)
        {
            if (dateFirst._timestamp == 0)
                return new CDate(0) { isValid = false };
            return new CDate(dateFirst._timestamp - 1);
        }
        public static CDate operator -(CDate dateFirst, ulong days)
        {
            if (dateFirst._timestamp < days)
                return new CDate(0) { isValid = false };
            return new CDate(dateFirst._timestamp - days);
        }

        public static bool operator ==(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp == dateSecond._timestamp;
        }
        public static bool operator !=(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp != dateSecond._timestamp;
        }

        public static bool operator <(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp < dateSecond._timestamp;
        }
        public static bool operator >(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp > dateSecond._timestamp;
        }
        public static bool operator <=(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp <= dateSecond._timestamp;
        }
        public static bool operator >=(CDate dateFirst, CDate dateSecond)
        {
            return dateFirst._timestamp >= dateSecond._timestamp;
        }

        public static implicit operator string(CDate date)
        {
            return string.Format("{0,2:00}.{1,2:00}.{2,4:0000}", date.GetDay(), (uint)date.GetMonth(), date.GetYear());
        }

        public static explicit operator CDate(string dateString)
        {
            string[] parameters = dateString.Split('.');
            if (parameters.Length != 3)
                return new CDate(0, Month.JANUARY, 1969);
            ushort day = ushort.Parse(parameters[0]);
            ushort month = ushort.Parse(parameters[1]);
            ushort year = ushort.Parse(parameters[2]);
            return new CDate(day, (Month)month, year);
        }

        private YearType GetYearType(ushort year)
        {
            if (year % 4 != 0)
                return YearType.NOT_LEAP;
            if (year % 100 != 0)
                return YearType.LEAP;
            return (year % 400 == 0) ? YearType.LEAP: YearType.NOT_LEAP;
        }

        private ulong GetModOfYears()
        {
            ulong tempTimeStamp = _timestamp;
            ushort tempYear = startYear;
            while (tempTimeStamp > 0)
            {
                var days = typeYear[GetYearType(tempYear)];
                if (tempTimeStamp < days)
                    return tempTimeStamp;
                tempTimeStamp -= days;
                tempYear++;
            }
            return 0;
        }

        private ushort GetModOfMonth()
        {
            var tempDays = GetModOfYears();
            ulong subDays = 0;
            Month month = Month.JANUARY;
            ushort year = GetYear();
            while (tempDays > 0)
            {
                if (month == Month.FEBRUARY && GetYearType(year) == YearType.LEAP)
                    subDays = 29;
                else
                    subDays = dayInMonth[month];
                if (tempDays < subDays)
                    return (ushort)tempDays;
                tempDays -= subDays;
                month++;
            }
            return 0;
        }

        private ulong GetDaysBeforeMonth(Month month, ushort year)
        {
            ulong result = 0;
            Month currMonth = Month.JANUARY;
            while (currMonth != month)
            {
                if (currMonth == Month.FEBRUARY && GetYearType(year) == YearType.LEAP)
                    result += 29;
                else
                    result += (ushort)dayInMonth[currMonth];
                currMonth++;
            }
            return result;
        }
        private ulong GetDaysBeforeYear(ushort year)
        {
            ulong result = 0;
            ushort currYear = startYear;
            while (currYear != year)
            {
                result += typeYear[GetYearType(currYear)];
                currYear++;
            }
            return result;
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
