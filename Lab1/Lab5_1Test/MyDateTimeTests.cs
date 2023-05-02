using Lab5_1;
using System;

namespace Lab5_1Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DateManyParams_OK()
        {
            ushort day = 1;
            Month month = Month.JANUARY;
            ushort year = 1970;
            CDate date = new CDate(day, month, year);

            Assert.AreEqual(day, date.GetDay());
            Assert.AreEqual(month, date.GetMonth());
            Assert.AreEqual(year, date.GetYear());
        }

        [Test]
        public void DateFromTimestamp_OK()
        {
            ulong timestamp = 1;
            CDate date = new CDate(timestamp);

            Assert.AreEqual(2, date.GetDay());
            Assert.AreEqual(Month.JANUARY, date.GetMonth());
            Assert.AreEqual(1970, date.GetYear());
        }
    }
}