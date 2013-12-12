using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Extensions;

namespace MMLib.Extensions.Test
{
    [TestClass]
    public class StringExtensions
    {

        [TestMethod]
        public void RemoveDiacritics_NullAndEmptyTest()
        {
            string target = string.Empty;
            Assert.AreEqual(string.Empty, target.RemoveDiacritics());

            target = null;
            Assert.AreEqual(null, target.RemoveDiacritics());


            target = "   ";
            Assert.AreEqual(target, target.RemoveDiacritics());
        }

        [TestMethod]
        public void RemoveDiacritics_Test()
        {
            string target = "+ľščťžýáíéqwertyuiopasdfghjklô§ň&zxcvbnm,.-_:?MNBVCXZ)!LKJHGFDSA(/POIUYTREWQŠŘČŇŽÍÁÉÚ";
            string expected = "+lsctzyaieqwertyuiopasdfghjklo§n&zxcvbnm,.-_:?MNBVCXZ)!LKJHGFDSA(/POIUYTREWQSRCNZIAEU";
            string actual = target.RemoveDiacritics();

            Assert.AreEqual(expected, actual);
        }
    }
}
