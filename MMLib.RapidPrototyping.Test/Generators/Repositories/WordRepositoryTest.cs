using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.RapidPrototyping.Generators.Repositories;

namespace MMLib.RapidPrototyping.Test.Generators.Repositories
{
    [TestClass]
    public class WordRepositoryTest
    {
        [TestMethod]
        public void CountTest()
        {
            WordRepository target = new WordRepository(string.Format("ahoj{0}cau{0}ako{0}", Environment.NewLine));

            Assert.AreEqual(3, target.Count);
        }

        [TestMethod]
        public void IndexerTest()
        {
            WordRepository target = new WordRepository(string.Format("ahoj{0}cau{0}ako{0}", Environment.NewLine));

            Assert.AreEqual("ahoj", target[0]);
            Assert.AreEqual("cau", target[1]);
            Assert.AreEqual("ako", target[2]);
        }
    }
}
