using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Extensions;
using System.Collections.Generic;

namespace MMLib.Extensions.Test
{
    [TestClass]
    public class StringExtensions
    {

        #region Remove diacritics

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

        #endregion


        #region Truncate Tests

        [TestMethod]
        public void Truncate_NullTest()
        {
            string original = null;
            string expected = original;
            string actual = original.Truncate(10);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_StringEmptyTest()
        {
            string original = string.Empty;
            string expected = original;
            string actual = original.Truncate(10);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_NoTextTest()
        {
            string original = "";
            string expected = original;
            string actual = original.Truncate(10);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_LongerTextTest()
        {
            string original = "To tá heľpa je ale za pesnička obstarožná.";
            string expected = "To tá heľp";
            string actual = original.Truncate(10);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_ShorterTest()
        {
            string original = "To tá heľpa je ale za pesnička obstarožná.";
            string expected = original;
            string actual = original.Truncate(200);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_SameLengthTest()
        {
            string original = "Hello Kitty";
            string expected = original;
            string actual = original.Truncate(11);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Truncate_ZeroLengthTest()
        {
            string original = "Poziarnik Sam";
            string expected = string.Empty;
            string actual = original.Truncate(0);

            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region RemoveChars Tests

        [TestMethod]
        public void RemoveChars_NullOwnerNullTest()
        {
            string original = null;
            string actual = original.RemoveChars(null);

            Assert.IsNull(actual);
        }


        [TestMethod]
        public void RemoveChars_NullOwnerStringEmptyTest()
        {
            string original = null;
            string actual = original.RemoveChars(string.Empty);

            Assert.IsNull(actual);
        }


        [TestMethod]
        public void RemoveChars_NullOwnerNoTextTest()
        {
            string original = null;
            string actual = original.RemoveChars("");

            Assert.IsNull(actual);
        }


        [TestMethod]
        public void RemoveChars_NullOwnerRemoveTest()
        {
            string original = null;
            string actual = original.RemoveChars("Nothing goes happend. It is still returning null.");

            Assert.IsNull(actual);
        }


        [TestMethod]
        public void RemoveChars_NullTest()
        {
            string original = "Hello Kitty";
            string expected = original;
            string actual = original.RemoveChars(null);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RemoveChars_StringEmptyTest()
        {
            string original = "Hello Kitty";
            string expected = original;
            string actual = original.RemoveChars(string.Empty);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RemoveChars_NoTextTest()
        {
            string original = "Hello Kitty";
            string expected = original;
            string actual = original.RemoveChars("");

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RemoveChars_RemoveTest()
        {
            string original = "Hel*lo <Ki/tty";
            string expected = "Hello Kitty";
            string actual = original.RemoveChars("*?</");

            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region Split by separator tests

        [TestMethod]
        public void SplitBySeparatorTest()
        {
            string value = "1;2;3;4;5;6";
            IList<string> actual = value.SplitBySeparator(";");

            Assert.AreEqual(6, actual.Count);
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual((i + 1).ToString(), actual[i]);
            }
        }


        [TestMethod]
        public void SplitBySeparatorendSeparatorTest()
        {
            string value = "1;2;3;4;5;6;";
            IList<string> actual = value.SplitBySeparator(";");

            Assert.AreEqual(6, actual.Count);
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual((i + 1).ToString(), actual[i]);
            }
        }


        [TestMethod]
        public void SplitBySeparatorDoubleSeparatorTest()
        {
            string value = "1;2;3;4;;5;6;";
            IList<string> actual = value.SplitBySeparator(";");

            Assert.AreEqual(6, actual.Count);
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual((i + 1).ToString(), actual[i]);
            }
        }


        [TestMethod]
        public void SplitBySeparator_NewLineNotDeleteEmptyLinesTest()
        {
            string value = "1\r\n2\r\n\r\n3\r\n";
            IList<string> actual = value.SplitBySeparator(Environment.NewLine, false);

            Assert.AreEqual(5, actual.Count);
            Assert.AreEqual("1", actual[0]);
            Assert.AreEqual("2", actual[1]);
            Assert.AreEqual("", actual[2]);
            Assert.AreEqual("3", actual[3]);
            Assert.AreEqual("", actual[4]);
        }


        [TestMethod]
        public void SplitBySeparator_NewLineDeleteEmptyLinesTest()
        {
            string value = "1\r\n2\r\n\r\n3\r\n";
            IList<string> actual = value.SplitBySeparator(Environment.NewLine, true);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("1", actual[0]);
            Assert.AreEqual("2", actual[1]);
            Assert.AreEqual("3", actual[2]);
        }


        [TestMethod]
        public void SplitBySeparator_NewLineTest()
        {
            string value = "1\r\n2\r\n\r\n3\r\n";
            IList<string> actual = value.SplitBySeparator(Environment.NewLine);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("1", actual[0]);
            Assert.AreEqual("2", actual[1]);
            Assert.AreEqual("3", actual[2]);
        }

        #endregion


        #region SafeTrimStart Tests

        [TestMethod]
        public void SafeTrimStartTest()
        {
            string value = null;
            Assert.IsNull(value.SafeTrimStart());
            value = string.Empty;
            Assert.AreEqual(string.Empty, value.SafeTrimStart());
            value = "Bilango";
            Assert.AreEqual(value.TrimStart(), value.SafeTrimStart());
        }

        #endregion


        #region SafeLength Tests

        [TestMethod]
        public void SafeLengthTest()
        {
            string value = null;
            Assert.AreEqual(0, value.SafeLength());
            value = string.Empty;
            Assert.AreEqual(value.Length, value.SafeLength());
            value = "Bilango";
            Assert.AreEqual(value.Length, value.SafeLength());
        }

        #endregion


        #region SafeSubstring

        [TestMethod]
        public void SafeSubstringTest()
        {
            string target = null;

            Assert.IsNull(target.SafeSubstring(1));

            target = string.Empty;
            Assert.AreEqual(string.Empty, target.SafeSubstring(10));

            target = " ";
            Assert.AreEqual(" ", target.SafeSubstring(10));

            target = "Mino";
            Assert.AreEqual("M", target.SafeSubstring(1));
            Assert.AreEqual("Mi", target.SafeSubstring(2));
            Assert.AreEqual("Min", target.SafeSubstring(3));
            Assert.AreEqual("Mino", target.SafeSubstring(4));
            Assert.AreEqual("Mino", target.SafeSubstring(5));
        }

        #endregion


        #region IsNumber test

        [TestMethod]
        public void IsNumber_TrueTest()
        {
            string target = "1224352";

            Assert.IsTrue(target.IsNumber());

            target = "123,243";
            Assert.IsTrue(target.IsNumber());

            target = "123,243";
            Assert.IsTrue(target.IsNumber());

            target = "123,00";
            Assert.IsTrue(target.IsNumber());

            target = "0,243";
            Assert.IsTrue(target.IsNumber());
        }


        [TestMethod]
        public void IsNumber_FalseTest()
        {
            string target = null;

            Assert.IsFalse(target.IsNumber());

            target =string.Empty;
            Assert.IsFalse(target.IsNumber());

            target = "1a";
            Assert.IsFalse(target.IsNumber());

            target = "1.3";
            Assert.IsFalse(target.IsNumber());

            target = "a13";
            Assert.IsFalse(target.IsNumber());
        } 

        #endregion


        #region Examples

        [TestMethod]
public void Example_Tests()
{
    string target = "aácčeéií";
    Assert.AreEqual("aacceeii", target.RemoveDiacritics());

    target = "123,354";
    Assert.IsTrue(target.IsNumber());

    target = "Very long sentence";

    Assert.AreEqual("Very long", target.Truncate(9));
} 

        #endregion
    }
}
