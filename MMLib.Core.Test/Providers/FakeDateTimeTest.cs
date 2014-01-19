﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Core.Providers;

namespace MMLib.Core.Test.Providers
{
    [TestClass]
    public class FakeDateTimeTest
    {
        [TestMethod]
        public void Now_Test()
        {
            DateTime now = DateTime.Now;
            DateTimeProvider.Default = new FakeDateTime(now);

            Assert.AreEqual(now, DateTimeProvider.Default.Now);
        }


        [TestMethod]
        public void Today_Test()
        {
            DateTime now = DateTime.Now;
            DateTimeProvider.Default = new FakeDateTime(now);

            Assert.AreEqual(now.Date, DateTimeProvider.Default.Today);
        }
    }
}