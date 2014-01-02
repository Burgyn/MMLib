using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Extensions;

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
    }
}
