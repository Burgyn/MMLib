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

            target = string.Empty;
            Assert.IsFalse(target.IsNumber());

            target = "1a";
            Assert.IsFalse(target.IsNumber());

            target = "1.3";
            Assert.IsFalse(target.IsNumber());

            target = "a13";
            Assert.IsFalse(target.IsNumber());
        }

        #endregion


        #region Null or empty or white space test


        [TestMethod]
        public void IsNullOrEmpty_TrueTest()
        {
            string target = null;
            Assert.IsTrue(target.IsNullOrEmpty());

            target = string.Empty;
            Assert.IsTrue(target.IsNullOrEmpty());
        }


        [TestMethod]
        public void IsNullOrEmpty_FalseTest()
        {
            string target = "sdfsgfsd";
            Assert.IsFalse(target.IsNullOrEmpty());

            target = " ";
            Assert.IsFalse(target.IsNullOrEmpty());
        }


        [TestMethod]
        public void IsNullOrWhiteTest_TrueTest()
        {
            string target = null;
            Assert.IsTrue(target.IsNullOrWhiteSpace());

            target = string.Empty;
            Assert.IsTrue(target.IsNullOrWhiteSpace());

            target = " ";
            Assert.IsTrue(target.IsNullOrWhiteSpace());

            target = "    ";
            Assert.IsTrue(target.IsNullOrWhiteSpace());
        }


        [TestMethod]
        public void IsNullOrWhiteTest_FalseTest()
        {
            string target = "sdfsgfsd";
            Assert.IsFalse(target.IsNullOrWhiteSpace());

            target = "wwr";
            Assert.IsFalse(target.IsNullOrWhiteSpace());
        }

        #endregion


        #region Format tests

        [TestMethod]
        public void FormatAsPattern_Test()
        {
            string target = "Hello {0}";

            Assert.AreEqual("Hello word", target.FormatAsPattern("word"));

            Assert.AreEqual("Hello 1", target.FormatAsPattern(1));

            target = "Count down {5}, {4}, {3}, {2}, {1}, {0}";

            Assert.AreEqual("Count down 5, 4, 3, 2, 1, 0", target.FormatAsPattern(0, 1, 2, 3, 4, 5));
        }

        #endregion


        #region Default if null

        [TestMethod]
        public void DefaultIfNull_TestStringEmpty()
        {
            string target = null;
            Assert.AreEqual(string.Empty, target.DefaultIfNull());

            target = "";
            Assert.AreEqual("", target.DefaultIfNull());

            target = " ";
            Assert.AreEqual(" ", target.DefaultIfNull());

            target = "asdf";
            Assert.AreEqual("asdf", target.DefaultIfNull());
        }


        [TestMethod]
        public void DefaultIfNull_Test()
        {
            string target = null;
            Assert.AreEqual("hello", target.DefaultIfNull("hello"));

            target = "";
            Assert.AreEqual("", target.DefaultIfNull("hello"));

            target = " ";
            Assert.AreEqual(" ", target.DefaultIfNull("hello"));

            target = "asdf";
            Assert.AreEqual("asdf", target.DefaultIfNull("hello"));
        }

        #endregion


        #region Join to string tests

        [TestMethod]
        public void JoinToString_ObjectsTest()
        {
            object[] target = new object[] { "Count down", 3, 2, 1, 0, null, string.Empty, "Done" };

            Assert.AreEqual("Count down,3,2,1,0,Done", target.JoinToString(","));
            Assert.AreEqual("Count down3210Done", target.JoinToString(null));
        }


        [TestMethod]
        public void JoinToString_ListTest()
        {
            List<string> target = new List<string>() { "Count down", "3", "2", "1", "0", null, string.Empty, "Done" };

            Assert.AreEqual("Count down,3,2,1,0,Done", target.JoinToString(","));
            Assert.AreEqual("Count down3210Done", target.JoinToString(null));
        }

        #endregion


        #region IsValid email address

        [TestMethod]
        public void IsValidEmailAddress_TrueTest()
        {
            Assert.IsTrue("mino@gmail.com".IsValidEmailAddress());
            Assert.IsTrue("mino.gelecak@microsof.sk".IsValidEmailAddress());
            Assert.IsTrue("peter.gokola@penta.cz".IsValidEmailAddress());
            Assert.IsTrue("peter1.gokola@penta.cz".IsValidEmailAddress());
        }


        [TestMethod]
        public void IsValidEmailAddress_TalseTest()
        {
            Assert.IsFalse("mino@gmail.c".IsValidEmailAddress());
            Assert.IsFalse("mino.gelecak@microsof.skffd".IsValidEmailAddress());
            Assert.IsFalse("mino.gelecak@microsof".IsValidEmailAddress());
            Assert.IsFalse("mino.gel&ecak@microsof.sk".IsValidEmailAddress());
            Assert.IsFalse("mino.gelec@ak@microsof.sk".IsValidEmailAddress());
            Assert.IsFalse("m^ino.gelecak@microsof.sk".IsValidEmailAddress());
            Assert.IsFalse("mino.gelecak@micr)osof.sk".IsValidEmailAddress());
            Assert.IsFalse("m!ino.gelecak@microsof.sk".IsValidEmailAddress());
            Assert.IsFalse("mi\no.gelecak@microsof.sk".IsValidEmailAddress());
            Assert.IsFalse("min%o.gelecak@microsof.sk".IsValidEmailAddress());
        } 

        #endregion


        #region IsValid IP address

        [TestMethod]
        public void IsValidIPAddress_TrueTest()
        {
            Assert.IsTrue("111.2.33.4".IsValidIPAddress());
            Assert.IsTrue("1.1.1.1".IsValidIPAddress());
            Assert.IsTrue("0.0.0.0".IsValidIPAddress());
            Assert.IsTrue("255.255.255.255".IsValidIPAddress());
            Assert.IsTrue("255.0.0.0".IsValidIPAddress());
            Assert.IsTrue("196.168.1.1".IsValidIPAddress());

            Assert.IsTrue("2001:0db8:85a3:0000:1319:8a2e:0370:7344".IsValidIPAddress());
            Assert.IsTrue("2001:0db8:85a3::1319:8a2e:0370:7344".IsValidIPAddress());            
        }

        [TestMethod]
        public void IsValidIPAddress_FalseTest()
        {
            Assert.IsFalse("1a11.2.33.4".IsValidIPAddress());
            Assert.IsFalse("1.1.1.1.1".IsValidIPAddress());
            Assert.IsFalse("0.0.0.256".IsValidIPAddress());
            Assert.IsFalse("256.255.255.255".IsValidIPAddress());
            Assert.IsFalse("255-.0.0.0".IsValidIPAddress());
            Assert.IsFalse("300.168.1.1".IsValidIPAddress());

            Assert.IsFalse("2002341:0db8:85a3:0000:1319:8a2e:0370:7344".IsValidIPAddress());
        } 

        #endregion


        #region IsValid URL address

        [TestMethod]
        public void IsValidURLAddress_TrueTest()
        {
            Assert.IsTrue("https://mmlib.codeplex.com/".IsValidUrlAddress());
            Assert.IsTrue("www.mmlib.codeplex.com".IsValidUrlAddress());
            Assert.IsTrue("https://mmlib.codeplex.com/SourceControl/latest".IsValidUrlAddress());
            Assert.IsTrue("www.google.com".IsValidUrlAddress());
            Assert.IsTrue("www.google.sk".IsValidUrlAddress());
        }


        [TestMethod]
        public void IsValidURLAddress_FalseTest()
        {          
            Assert.IsFalse("https:///mmlib.codeplex.com/SourceControl/latest".IsValidUrlAddress());
            Assert.IsFalse("www.google.sk[]'\'/';;".IsValidUrlAddress());
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
