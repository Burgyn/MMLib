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
    }
}
