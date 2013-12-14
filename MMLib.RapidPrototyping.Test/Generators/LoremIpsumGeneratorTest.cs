using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.RapidPrototyping.Generators;
using MMLib.RapidPrototyping.Generators.Repositories;

namespace MMLib.RapidPrototyping.Test.Generators
{
    [TestClass]
    public class LoremIpsumGeneratorTest
    {
        [TestMethod]
        public void Next_Test()
        {
            LoremIpsumGenerator target = new LoremIpsumGenerator(10, new LoremIpsumRepository(Properties.Resources.loremIpsum));
            string expected = @"Ac in tortor, quisque lectus, cubilia non bibendum. Ac in tortor, quisque lectus, cubilia non bibendum. Ac in tortor, quisque lectus, cubilia non bibendum. Teraz to zhaslo. Non nisl in, metus proin. Non nisl in, metus proin. Este furt to sviet.
Bibendum magna, sit lectus. Teraz to zhaslo. Ut justo, sodales proin arcu, vitae luctus mollis. Bibendum magna, sit lectus. Elementum feugiat velit, dictum libero. Teraz to zhaslo. Lubim Ta. Este furt to sviet.
";
            var actual = target.Next(2);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Next_SentencesLimitationTest()
        {
            LoremIpsumGenerator target = new LoremIpsumGenerator(10, new LoremIpsumRepository(Properties.Resources.loremIpsum));
            string expected = @"Ac in tortor, quisque lectus, cubilia non bibendum. Ac in tortor, quisque lectus, cubilia non bibendum.
Ac in tortor, quisque lectus, cubilia non bibendum. Teraz to zhaslo.
Non nisl in, metus proin.
";
            var actual = target.Next(3, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
