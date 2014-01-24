using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Extensions;
using MMLib.Core.Providers;
using MMLib.Core.Providers.Fakes;

namespace MMLib.Extensions.Test
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        #region IsWeekend

        [TestMethod]
        public void IsWeekend_TrueTest()
        {
            DateTime target = new DateTime(2014, 1, 4);
            Assert.IsTrue(target.IsWeekend());

            target = new DateTime(2014, 1, 5);
            Assert.IsTrue(target.IsWeekend());

            target = new DateTime(2013, 12, 28);
            Assert.IsTrue(target.IsWeekend());

            target = new DateTime(2013, 12, 29);
            Assert.IsTrue(target.IsWeekend());
        }


        [TestMethod]
        public void IsWeekend_FalseTest()
        {
            DateTime target = new DateTime(2014, 1, 3);
            Assert.IsFalse(target.IsWeekend());

            target = new DateTime(2014, 1, 6);
            Assert.IsFalse(target.IsWeekend());

            target = new DateTime(2014, 1, 9);
            Assert.IsFalse(target.IsWeekend());

            target = new DateTime(2012, 9, 12);
            Assert.IsFalse(target.IsWeekend());

            target = new DateTime(2015, 8, 5);
            Assert.IsFalse(target.IsWeekend());
        }

        #endregion


        #region IsLeapYear

        [TestMethod]
        public void IsLeapYear_TrueTest()
        {
            DateTime target = new DateTime(2012, 1, 4);
            Assert.IsTrue(target.IsLeapYear());

            target = new DateTime(2008, 2, 14);
            Assert.IsTrue(target.IsLeapYear());

            target = new DateTime(2016, 2, 29);
            Assert.IsTrue(target.IsLeapYear());
        }


        [TestMethod]
        public void IsLeapYear_FalseTest()
        {
            DateTime target = new DateTime(2014, 1, 4);
            Assert.IsFalse(target.IsLeapYear());

            target = new DateTime(2013, 2, 14);
            Assert.IsFalse(target.IsLeapYear());

            target = new DateTime(2015, 2, 28);
            Assert.IsFalse(target.IsLeapYear());
        }

        #endregion


        #region IsLastDayOfMonth

        [TestMethod]
        public void IsLastDayOfMonth_TrueTest()
        {
            DateTime target = new DateTime(2012, 1, 31);
            Assert.IsTrue(target.IsLastDayOfMonth());

            target = new DateTime(2012, 2, 29);
            Assert.IsTrue(target.IsLastDayOfMonth());

            target = new DateTime(2013, 2, 28);
            Assert.IsTrue(target.IsLastDayOfMonth());

            target = new DateTime(2012, 4, 30);
            Assert.IsTrue(target.IsLastDayOfMonth());

            target = new DateTime(2012, 8, 31);
            Assert.IsTrue(target.IsLastDayOfMonth());
        }


        [TestMethod]
        public void IsLastDayOfMonth_FalseTest()
        {
            DateTime target = new DateTime(2012, 1, 30);
            Assert.IsFalse(target.IsLastDayOfMonth());

            target = new DateTime(2013, 2, 27);
            Assert.IsFalse(target.IsLastDayOfMonth());

            target = new DateTime(2012, 2, 28);
            Assert.IsFalse(target.IsLastDayOfMonth());

            target = new DateTime(2012, 3, 20);
            Assert.IsFalse(target.IsLastDayOfMonth());

            target = new DateTime(2012, 8, 30);
            Assert.IsFalse(target.IsLastDayOfMonth());
        }

        #endregion


        #region IsInRange

        [TestMethod]
        public void IsInRange_TrueTest()
        {
            DateTime target = new DateTime(2001, 1, 1);
            DateTime start = new DateTime(2001, 1, 1);
            DateTime end = new DateTime(2001, 2, 1);
            Assert.IsTrue(target.IsInRange(start, end));

            target = new DateTime(2001, 1, 1);
            start = new DateTime(2000, 1, 1);
            end = new DateTime(2004, 2, 1);
            Assert.IsTrue(target.IsInRange(start, end));

            target = new DateTime(2001, 2, 1);
            start = new DateTime(2000, 1, 1);
            end = new DateTime(2001, 2, 1);
            Assert.IsTrue(target.IsInRange(start, end));

            target = new DateTime(2001, 1, 1, 4, 4, 4);
            start = new DateTime(2001, 1, 1, 4, 4, 3);
            end = new DateTime(2004, 2, 1);
            Assert.IsTrue(target.IsInRange(start, end));


            target = new DateTime(2001, 1, 1, 4, 4, 4);
            start = new DateTime(2001, 1, 1, 4, 4, 4);
            end = new DateTime(2004, 2, 1);
            Assert.IsTrue(target.IsInRange(start, end));
        }


        [TestMethod]
        public void IsInRange_FalseTest()
        {
            DateTime target = new DateTime(2000, 1, 1);
            DateTime start = new DateTime(2001, 1, 1);
            DateTime end = new DateTime(2001, 2, 1);
            Assert.IsFalse(target.IsInRange(start, end));

            target = new DateTime(2005, 1, 1);
            start = new DateTime(2000, 1, 1);
            end = new DateTime(2004, 2, 1);
            Assert.IsFalse(target.IsInRange(start, end));

            target = new DateTime(2001, 2, 2);
            start = new DateTime(2000, 1, 1);
            end = new DateTime(2001, 2, 1);
            Assert.IsFalse(target.IsInRange(start, end));

            target = new DateTime(2001, 3, 1);
            start = new DateTime(2000, 1, 1);
            end = new DateTime(2001, 2, 1);
            Assert.IsFalse(target.IsInRange(start, end));

            target = new DateTime(2001, 1, 1, 4, 4, 2);
            start = new DateTime(2001, 1, 1, 4, 4, 3);
            end = new DateTime(2004, 2, 1);
            Assert.IsFalse(target.IsInRange(start, end));
        }

        #endregion


        #region Age

        [TestMethod]
        public void Age_Test()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 1, 14));
            DateTime birthDay = new DateTime(1985, 8, 23);
            Assert.AreEqual(28, birthDay.Age());

            birthDay = new DateTime(1986, 8, 23);
            Assert.AreEqual(27, birthDay.Age());

            birthDay = new DateTime(1985, 1, 15);
            Assert.AreEqual(28, birthDay.Age());

            birthDay = new DateTime(1985, 1, 14);
            Assert.AreEqual(29, birthDay.Age());

            birthDay = new DateTime(1985, 1, 13);
            Assert.AreEqual(29, birthDay.Age());


            DateTimeProvider.Default = new FakeDateTime(new DateTime(2000, 2, 28));
            birthDay = new DateTime(2000, 2, 28);
            Assert.AreEqual(0, birthDay.Age());

            birthDay = new DateTime(2000, 2, 27);
            Assert.AreEqual(0, birthDay.Age());

            birthDay = new DateTime(1999, 2, 28);
            Assert.AreEqual(1, birthDay.Age());
        }

        #endregion


        #region IsToday

        [TestMethod]
        public void IsToday_TrueTest()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 1, 14));
            DateTime target = new DateTime(2014, 1, 14);
            Assert.IsTrue(target.IsToday());

            target = new DateTime(2014, 1, 14, 0, 0, 0, 0);
            Assert.IsTrue(target.IsToday());

            target = new DateTime(2014, 1, 14, 0, 0, 0, 1);
            Assert.IsTrue(target.IsToday());

            target = new DateTime(2014, 1, 14, 0, 0, 1, 0);
            Assert.IsTrue(target.IsToday());

            target = new DateTime(2014, 1, 14, 1, 0, 0, 0);
            Assert.IsTrue(target.IsToday());

            target = new DateTime(2014, 1, 14, 23, 59, 59, 999);
            Assert.IsTrue(target.IsToday());
        }


        [TestMethod]
        public void IsToday_FalseTest()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 1, 14));
            DateTime target = new DateTime(2014, 1, 15);
            Assert.IsFalse(target.IsToday());

            target = new DateTime(2014, 1, 16);
            Assert.IsFalse(target.IsToday());

            target = new DateTime(2014, 1, 15, 0, 0, 0, 1);
            Assert.IsFalse(target.IsToday());

            target = new DateTime(2014, 1, 13, 23, 59, 59, 999);
            Assert.IsFalse(target.IsToday());
        }

        #endregion
    }
}
