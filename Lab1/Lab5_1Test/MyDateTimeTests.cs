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
            CDate date = new CDate(day, month, year);

            Assert.AreEqual(day, date.GetDay());
            Assert.AreEqual(month, date.GetMonth());
            Assert.AreEqual(year, date.GetYear());
        }

        [Test]
        [TestCase((ushort)0, Month.JANUARY, (ushort)1970)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)1970)]
        [TestCase((ushort)29, Month.FEBRUARY, (ushort)1960)]
        [TestCase((ushort)1, Month.JANUARY, (ushort)10000)]
        public void DateManyParams_Bad(ushort day, Month month, ushort year)
        {
            Assert.IsFalse((new CDate(day, month, year)).IsValid());
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
        [TestCase((ulong)2932896, (ushort)31, Month.DECEMBER, (ushort)9999)]
        public void DateFromTimestamp_OK(ulong timeStamp, ushort expectedDay, Month expectedMonth, ushort expectedYear)
        {
            CDate date = new CDate(timeStamp);

            Assert.AreEqual(expectedDay, date.GetDay());
            Assert.AreEqual(expectedMonth, date.GetMonth());
            Assert.AreEqual(expectedYear, date.GetYear());
        }

        [Test]
        [TestCase((ulong)2932897)]
        public void DateFromTimestamp_Bad(ulong timeStamp)
        {
            CDate date = new CDate(timeStamp);
            Assert.IsFalse(date.IsValid());
        }

        [Test]
        [TestCase((ulong)0, (ulong)0, (ulong)0)]
        [TestCase((ulong)0, (ulong)1, (ulong)1)]
        [TestCase((ulong)2932895, (ulong)1, (ulong)2932896)]
        public void OperatorSummTests_OK(ulong timeStamp, ulong days, ulong expectedDays)
        {
            CDate date = new CDate(timeStamp);
            date += days;
            Assert.AreEqual(expectedDays, date.GetTimeStamp());
        }

        [Test]
        [TestCase((ulong)2932896, (ulong)1)]
        public void OperatorSummTests_Bad(ulong timeStamp, ulong days)
        {
            CDate date = new CDate(timeStamp);
            date += days;
            Assert.IsFalse(date.IsValid());
        }

        [Test]
        [TestCase((ulong)0, (ulong)0, (ulong)0)]
        [TestCase((ulong)1, (ulong)1, (ulong)0)]
        [TestCase((ulong)2932896, (ulong)2932896, (ulong)0)]
        public void OperatorSubTests_OK(ulong timeStamp, ulong days, ulong expectedDays)
        {
            CDate date = new CDate(timeStamp);
            date -= days;
            Assert.AreEqual(expectedDays, date.GetTimeStamp());
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        public void OperatorSubTests_Bad(ulong timeStamp, ulong days)
        {
            CDate date = new CDate(timeStamp);
            date -= days;
            Assert.IsFalse(date.IsValid());
        }

        [Test]
        [TestCase((ulong)0)]
        public void OperatorEqualsTests_Ok(ulong timeStamp)
        {
            CDate dateFirst = new CDate(timeStamp);
            CDate dateSecond = new CDate(timeStamp);
            Assert.IsTrue(dateFirst == dateSecond);
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        public void OperatorNotEqualsTests_Ok(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsTrue(dateFirst != dateSecond);
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        public void OperatorLessTests_Ok(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsTrue(dateFirst < dateSecond);
        }

        [Test]
        [TestCase((ulong)1, (ulong)0)]
        public void OperatorLessTests_Bad(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsFalse(dateFirst < dateSecond);
        }

        [Test]
        [TestCase((ulong)1, (ulong)0)]
        public void OperatorMoreTests_Ok(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsTrue(dateFirst > dateSecond);
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        public void OperatorMoreTests_Bad(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsFalse(dateFirst > dateSecond);
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        [TestCase((ulong)1, (ulong)1)]
        public void OperatorLessOrEqualTests_Ok(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsTrue(dateFirst <= dateSecond);
        }

        [Test]
        [TestCase((ulong)1, (ulong)0)]
        public void OperatorLessOrEqualTests_Bad(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsFalse(dateFirst <= dateSecond);
        }

        [Test]
        [TestCase((ulong)1, (ulong)0)]
        [TestCase((ulong)1, (ulong)1)]
        public void OperatorMoreOrEqualTests_Ok(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsTrue(dateFirst >= dateSecond);
        }

        [Test]
        [TestCase((ulong)0, (ulong)1)]
        public void OperatorMoreOrEqualTests_Bad(ulong firstTimeStamp, ulong secondTimeStamp)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            CDate dateSecond = new CDate(secondTimeStamp);
            Assert.IsFalse(dateFirst >= dateSecond);
        }

        [Test]
        [TestCase((ulong)0, "01.01.1970")]
        [TestCase((ulong)1, "02.01.1970")]
        public void ConsoleWriterTests_Ok(ulong firstTimeStamp, string stringDate)
        {
            CDate dateFirst = new CDate(firstTimeStamp);
            StringWriter sw = new StringWriter();
            sw.Write(dateFirst);
            Assert.IsTrue(sw.ToString() == stringDate);
        }

        [Test]
        [TestCase("01.01.1970", (ulong)0)]
        [TestCase("02.01.1970", (ulong)1)]
        public void ConsoleReaderTests_Ok(string stringDate, ulong expectedTimestamp)
        {
            CDate dateFirst = (CDate)stringDate;
            Assert.AreEqual(expectedTimestamp, dateFirst.GetTimeStamp());
        }

        //Тесты на негатив
        [Test]
        [TestCase("01")]
        [TestCase("0a.01.1970")]
        public void ConsoleReaderTests_Bad(string stringDate)
        {
            CDate dateFirst = (CDate)stringDate;
            Assert.IsFalse(dateFirst.IsValid());
        }
    }
}