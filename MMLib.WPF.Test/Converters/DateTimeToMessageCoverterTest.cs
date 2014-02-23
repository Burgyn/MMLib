using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Core.Providers;
using MMLib.Core.Providers.Fakes;
using MMLib.WPF.Converters;

namespace MMLib.WPF.Test.Converters
{
    [TestClass]
    public class DateTimeToMessageCoverterTest
    {
        [TestMethod]
        public void NowTest()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 2, 23, 18, 13, 23));
            DateTimeToMessageCoverter target = new DateTimeToMessageCoverter();

            DateTime value = new DateTime(2014, 2, 23, 18, 13, 23);
            Assert.AreEqual("now", target.Convert(value, null, null, null));

            value = new DateTime(2014, 2, 23, 18, 13, 22);
            Assert.AreEqual("now", target.Convert(value, null, null, null));

            value = new DateTime(2014, 2, 23, 18, 13, 00);
            Assert.AreEqual("now", target.Convert(value, null, null, null));

            value = new DateTime(2014, 2, 23, 18, 12, 30);
            Assert.AreEqual("now", target.Convert(value, null, null, null));

            value = new DateTime(2014, 2, 23, 18, 12, 23);
            Assert.AreNotEqual("now", target.Convert(value, null, null, null));

            value = new DateTime(2015, 2, 23, 18, 13, 21);
            Assert.AreNotEqual("now", target.Convert(value, null, null, null));
        }

        [TestMethod]
        public void MinutesTest()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 2, 23, 18, 13, 23));
            DateTimeToMessageCoverter target = new DateTimeToMessageCoverter();

            DateTime now = new DateTime(2014, 2, 23, 18, 12, 23);
            Assert.AreEqual("1 min. ago", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 18, 11, 24);
            Assert.AreEqual("2 min. ago", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 18, 3, 24);
            Assert.AreEqual("10 min. ago", target.Convert(now, null, null, null));

            now = new DateTime(2015, 2, 23, 18, 3, 24);
            Assert.AreNotEqual("10 min. ago", target.Convert(now, null, null, null));
        }

        [TestMethod]
        public void SameDay_Test()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 2, 23, 23, 59, 25));
            DateTimeToMessageCoverter target = new DateTimeToMessageCoverter();

            DateTime now = new DateTime(2014, 2, 23, 1, 12, 23);
            Assert.AreEqual("1:12", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 18, 24, 23);
            Assert.AreEqual("18:24", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 19, 15, 24);
            Assert.AreEqual("19:15", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 23, 39, 24);
            Assert.AreEqual("23:39", target.Convert(now, null, null, null));

            now = new DateTime(2015, 2, 23, 23, 39, 24);
            Assert.AreNotEqual("23:09", target.Convert(now, null, null, null));
        }

        [TestMethod]
        public void SameWeek_Test()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 2, 23, 1, 1, 23));
            DateTimeToMessageCoverter target = new DateTimeToMessageCoverter();

            DateTime now = new DateTime(2014, 2, 21, 1, 12, 23);
            Assert.AreEqual("pi 1:12", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 22, 1, 12, 23);
            Assert.AreEqual("so 1:12", target.Convert(now, null, null, null));

        }

        [TestMethod]
        public void DateTime_Test()
        {
            DateTimeProvider.Default = new FakeDateTime(new DateTime(2014, 3, 20, 1, 1, 23));
            DateTimeToMessageCoverter target = new DateTimeToMessageCoverter();

            DateTime now = new DateTime(2014, 2, 21, 1, 12, 23);
            Assert.AreEqual("21. feb. 1:12", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 22, 1, 12, 23);
            Assert.AreEqual("22. feb. 1:12", target.Convert(now, null, null, null));

            now = new DateTime(2014, 2, 23, 1, 12, 23);
            Assert.AreEqual("23. feb. 1:12", target.Convert(now, null, null, null));

            now = new DateTime(2015, 1, 20, 1, 12, 23);
            Assert.AreEqual("20. jan. 1:12", target.Convert(now, null, null, null));
        }
    }
}
