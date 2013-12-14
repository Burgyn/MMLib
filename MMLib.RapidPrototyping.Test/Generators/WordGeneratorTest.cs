using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MMLib.RapidPrototyping.Generators;
using System.Linq;

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


        [TestMethod]
        public void Next_MoreTest()
        {
            IWordGenerator target = new WordGenerator(1);
            var words = target.Next(4).ToList();

            Assert.AreEqual("cau", words[0]);
            Assert.AreEqual("ahoj", words[1]);
            Assert.AreEqual("nazdar", words[2]);
            Assert.AreEqual("dozor", words[3]);
        }
    }
}
