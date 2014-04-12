using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.WPF.Converters;

namespace MMLib.WPF.Test.Converters
{
    [TestClass]
    public class MinusDoubleConverterTest
    {
        [TestMethod]
        public void BaseTest()
        {
            MinusDoubleConverter target = new MinusDoubleConverter();
            double oreginalValue = 22;
            double parameterValue = 12;
            double expected = 10;

            Assert.AreEqual(expected, target.Convert(oreginalValue, null, parameterValue, null));

            oreginalValue = 42.5;
            parameterValue = 9;
            expected = 33.5;

            Assert.AreEqual(expected, target.Convert(oreginalValue, null, parameterValue, null));
        }
    }
}
