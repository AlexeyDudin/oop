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
        [TestCase((ushort)1, Month.JANUARY, (ushort)1970)]
        [TestCase((ushort)1, Month.FEBRUARY, (ushort)1970)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)1972)]
        [TestCase((ushort)31, Month.DECEMBER, (ushort)1970)]
        [TestCase((ushort)1, Month.JANUARY, (ushort)1971)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)2000)]
        public void DateManyParams_OK(ushort day, Month month, ushort year)
        {
            ICalendar date = new CDate(day, month, year);

            Assert.AreEqual(day, date.GetDay());
            Assert.AreEqual(month, date.GetMonth());
            Assert.AreEqual(year, date.GetYear());
        }

        [Test]
        [TestCase((ushort)0, Month.JANUARY, (ushort)1970)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)1970)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)1960)]
        [TestCase((ushort)31, Month.DECEMBER, (ushort)1970)]
        [TestCase((ushort)1, Month.JANUARY, (ushort)1971)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)2000)]
        public void DateManyParams_Bad(ushort day, Month month, ushort year)
        {
            Assert.Throws< ArgumentException >(() => new CDate(day, month, year));
        }

        [Test]
        [TestCase((ulong)0, (ushort)1, Month.JANUARY, (ushort)1970)]
        [TestCase((ulong)1, (ushort)2, Month.JANUARY, (ushort)1970)]
        [TestCase((ulong)30, (ushort)31, Month.JANUARY, (ushort)1970)]
        [TestCase((ulong)31, (ushort)1, Month.FEBRUARY, (ushort)1970)]
        [TestCase((ulong)58, (ushort)28, Month.FEBRUARY, (ushort)1970)]
        [TestCase((ulong)59, (ushort)1, Month.MARCH, (ushort)1970)]
        [TestCase((ulong)59, (ushort)1, Month.MARCH, (ushort)1970)]
        [TestCase((ulong)11016, (ushort)29, Month.FEBRUARY, (ushort)2000)]
        public void DateFromTimestamp_OK(ulong timeStamp, ushort expectedDay, Month expectedMonth, ushort expectedYear)
        {
            CDate date = new CDate(timeStamp);

            Assert.AreEqual(expectedDay, date.GetDay());
            Assert.AreEqual(expectedMonth, date.GetMonth());
            Assert.AreEqual(expectedYear, date.GetYear());
        }

        //[Test]
        //[TestCase(12)]
        //[TestCase(12)]
        //[TestCase(12)]
        //[TestCase(12)]
        //[TestCase(12)]
        //public void DateFromTimestamp_NextEndMonth_OK(ulong timeStamp)
        //{
        //    CDate date = new CDate(timeStamp);

        //    Assert.AreEqual(1, date.GetDay());
        //    Assert.AreEqual(Month.FEBRUARY, date.GetMonth());
        //    Assert.AreEqual(1970, date.GetYear());
        //}
    }
}