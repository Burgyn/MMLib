using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMLib.Extensions;

namespace MMLib.Extensions.Test
{
    [TestClass]
    public class ObjectExtensionsTest
    {
        [TestMethod]
        public void SetPropertyValue_Test()
        {
            DateTime now = DateTime.Now;

            TestClass target = new TestClass();
            Assert.IsTrue(target.SetPropertyValue("IntValue", 1));
            Assert.IsTrue(target.SetPropertyValue("StringValue", "Hello"));
            Assert.IsTrue(target.SetPropertyValue("DoubleValue", 12));
            Assert.IsTrue(target.SetPropertyValue("DateTimeValue", now));

            Assert.IsFalse(target.SetPropertyValue("Drttt", now));

            Assert.AreEqual(1, target.IntValue);
            Assert.AreEqual(12, target.DoubleValue);
            Assert.AreEqual("Hello", target.StringValue);
            Assert.AreEqual(now, target.DateTimeValue);
        }

        [TestMethod]
        public void GetPropertyValue_GenericTest()
        {
            DateTime now = DateTime.Now;

            TestClass target = new TestClass()
            {
                DateTimeValue = now,
                DoubleValue = 14,
                IntValue = 11,
                StringValue = "Hello"
            };

            Assert.AreEqual(now, target.GetPropertyValue<DateTime>("DateTimeValue"));
            Assert.AreEqual(14, target.GetPropertyValue<double>("DoubleValue"));
            Assert.AreEqual(11, target.GetPropertyValue<int>("IntValue"));
            Assert.AreEqual("Hello", target.GetPropertyValue<string>("StringValue"));
        }

        [TestMethod]
        public void GetPropertyValue_Test()
        {
            DateTime now = DateTime.Now;

            TestClass target = new TestClass()
            {
                DateTimeValue = now,
                DoubleValue = 14,
                IntValue = 11,
                StringValue = "Hello"
            };

            Assert.AreEqual(now, target.GetPropertyValue("DateTimeValue"));
            Assert.AreEqual(14, (double)target.GetPropertyValue("DoubleValue"));
            Assert.AreEqual(11, (int)target.GetPropertyValue("IntValue"));
            Assert.AreEqual("Hello", target.GetPropertyValue("StringValue"));
        }

        [TestMethod]
        public void GetPropertyValue_InvalidPropertyNameTest()
        {
            DateTime now = DateTime.Now;

            TestClass target = new TestClass();

            try
            {
                var value = target.GetPropertyValue<int>("23243");
                Assert.Fail("It must faild");
            }
            catch (ArgumentException)
            {
                //Ok
            }
        }
    }


    public class TestClass
    {
        public int IntValue { get; set; }

        public string StringValue { get; set; }

        public double DoubleValue { get; set; }

        public DateTime DateTimeValue { get; set; }
    }
}
