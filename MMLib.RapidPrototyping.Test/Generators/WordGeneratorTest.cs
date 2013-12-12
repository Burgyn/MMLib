using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MMLib.RapidPrototyping.Generators;

namespace MMLib.RapidPrototyping.Test.Generators
{
    [TestClass]
    public class WordGeneratorTest
    {
        [TestMethod]
        public void Next_Test()
        {
            IWordGenerator target = new WordGenerator(1);

            Assert.AreEqual("cau",target.Next());
            Assert.AreEqual("ahoj",target.Next());
            Assert.AreEqual("nazdar", target.Next());
            Assert.AreEqual("dozor", target.Next());
        }
    }
}
