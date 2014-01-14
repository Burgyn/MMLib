using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Core.Test.Providers
{
    [TestClass]
    public class DateTimeProviderTest
    {
        [TestMethod]
        public void Today_Test()
        {
            DateTimeProvider.Default = null;
            Assert.AreEqual(DateTime.Today, DateTimeProvider.Default.Today);
        }

        [TestMethod]
        public void Now_Test()
        {
            DateTimeProvider.Default = null;
            DateTime start = DateTime.Now;
            DateTime actual = DateTimeProvider.Default.Now;
            DateTime stop = DateTime.Now;

            Assert.IsTrue(actual >= start && actual <= stop);
        }
    }
}
