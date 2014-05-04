using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MMLib.Extensions
{
    /// <summary>
    /// Extensions for string
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Remove diacritics from string. Origin value can be null and String.Empty.
        /// </summary>
        /// <param name="value">Origin string value. </param>
        /// <returns>New string value without diacritics.</returns>
        public static string RemoveDiacritics(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                string stFormD = value.Normalize(NormalizationForm.FormD);
                int len = stFormD.Length;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < len; i++)
                {
                    System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                    if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[i]);
                    }
                }

                return (sb.ToString().Normalize(NormalizationForm.FormC));
            }
            else
            {
                return value;
            }
        }


        /// <summary>
        /// Truncate string to max lenght. Origin value can by null and String.Empty.
        /// </summary>
        /// <param name="value">Origin string value.</param>
        /// <param name="maxLength">Max length of new string. Greater than zero.</param>
        /// <returns>Truncated string.</returns>
        public static string Truncate(this string value,
                                              int maxLength)
        {
            Contract.Requires(maxLength >= 0);
            Contract.Ensures(string.IsNullOrEmpty(Contract.Result<string>()) || Contract.Result<string>().Length <= maxLength);

            string ret = value;

            if (string.IsNullOrEmpty(value))
            {
                ret = value;
            }
            else
            {
                if (value.Length > maxLength)
                {
                    ret = value.Substring(0, maxLength);
                }
            }

            return ret;
        }


        /// <summary>
        /// Remove unexpected chars from string.
        /// </summary>
        /// <param name="value">Origin string value. Can by null and String.Empty.</param>
        /// <param name="unexpectedCharsString">String with unexpected chars. Can by null and String.Empty.</param>
        /// <returns>New string without unexpected chars</returns>
        public static string RemoveChars(this string value,
                                              string unexpectedCharsString)
        {
            string ret = value;

            if (!(string.IsNullOrEmpty(value) || string.IsNullOrEmpty(unexpectedCharsString)))
            {
                foreach (var item in unexpectedCharsString)
                {
                    var str = item.ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        ret = ret.Replace(str, string.Empty);
                    }
                }
            }

            return ret;
        }


        /// <summary>
        /// Split string by string separator.
        /// </summary>
        /// <param name="value">Origin string.</param>
        /// <param name="separator">Separator for spliting origin string.</param>
        /// <returns>
        /// Splited by separator.
        /// </returns>
        public static IList<string> SplitBySeparator(this string value,
                                                          string separator)
        {
            return SplitBySeparator(value, separator, true);
        }


        /// <summary>
        /// Split string by string separator.
        /// </summary>
        /// <param name="value">Origin string.</param>
        /// <param name="separator">Separator for spliting origin string.</param>
        /// <param name="canRemoveEmptyLines">
        /// True, if can remove empty lines. Else false.
        /// </param>
        /// <returns>
        /// Splited by separator.
        /// </returns>
        public static IList<string> SplitBySeparator(this string value,
                                                          string separator,
                                                            bool canRemoveEmptyLines)
        {
            List<string> ret = new List<string>();

            if (!string.IsNullOrEmpty(value))
            {
                var splitOptions = canRemoveEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
                ret = value.Split(new string[] { separator }, splitOptions).ToList();
            }

            return ret;
        }


        /// <summary>
        /// Removes all leading occurrences of a set of characters specified in an array from the current System.String object.
        /// If value is null then return null.
        /// </summary>
        /// <param name="value">
        /// Origin string value.
        /// </param>
        /// <returns>
        /// The string that remains after all occurrences of characters in the trimChars
        /// parameter are removed from the start of the current string. If trimChars
        /// is null or an empty array, white-space characters are removed instead.
        /// </returns>
        public static string SafeTrimStart(this string value)
        {
            return value == null ? value : value.TrimStart();
        }


        /// <summary>
        /// Gets the number of characters in the current System.String object.
        /// If value is null then return 0.
        /// </summary>
        /// <param name="value">Origin string value.</param>
        /// <returns>The number of characters in the current string.</returns>
        public static int SafeLength(this string value)
        {
            return value == null ? 0 : value.Length;
        }


        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// If value is null or empty then return origin text.
        /// </summary>
        /// <param name="value">Origin string value.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        /// A string that is equivalent to the substring of length length that begins
        /// at startIndex in this instance, or System.String.Empty if startIndex is equal
        /// to the length of this instance and length is zero.
        /// </returns>
        public static string SafeSubstring(this string value,
                                                   int length)
        {
            Contract.Requires(length > 0);

            Contract.Assert(length > 0);
            string ret = value;
            var len = value.SafeLength();

            if (len > 0 && length < len)
            {
                ret = value.Substring(0, length);
            }

            if (string.IsNullOrEmpty(ret))
            {
                ret = value;
            }

            return ret;
        }


        /// <summary>
        /// Check, if string value is number.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns>True: if string value is number, else False.</returns>
        public static bool IsNumber(this string value)
        {
            double number;

            bool ret = false;

            if (!string.IsNullOrEmpty(value))
            {
                ret = double.TryParse(value.Trim(), out number);
            }

            return ret;
        }


        /// <summary>
        ///  Indicates whether the specified string is null or an System.String.Emptystring.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }


        /// <summary>
        ///  Indicates whether a specified string is null, empty, or consists only of  white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns> true if the value parameter is null or System.String.Empty, or if value consists
        ///     exclusively of white-space characters.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation
        ///     of a specified object.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>A copy of format in which any format items are replaced by the string representation of arg0.</returns>
        /// <exception cref="System.FormatException">
        /// The format item in format is invalid.-or- The index of a format item is not zero.
        /// </exception>
        public static string FormatAsPattern(this string format, object arg0)
        {
            Contract.Requires(!format.IsNullOrWhiteSpace());

            return string.Format(format, arg0);
        }


        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation
        ///     of a corresponding object in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which any format items are replaced by the string representation of the corresponding objects in args.</returns>
        /// <exception cref="System.FormatException">
        /// The format item in format is invalid.-or- The index of a format item is not zero.
        /// </exception>
        public static string FormatAsPattern(this string format, params object[] args)
        {
            Contract.Requires(!format.IsNullOrWhiteSpace());

            return string.Format(format, args);
        }


        /// <summary>
        /// Join values to one string with separator.
        /// </summary>
        /// <param name="values">Values for join.</param>
        /// <param name="separator">Separator.</param>
        /// <returns>String, which contain joined values with separator.</returns>
        public static string JoinToString(this object[] values, string separator)
        {
            Contract.Requires(values != null);
            StringBuilder ret = new StringBuilder();
            bool wasAppendedSeparator = false;

            foreach (var item in values.Where(p => p != null).Select(p => p.ToString()))
            {
                if (!item.IsNullOrEmpty())
                {
                    ret.Append(item);
                    if (!separator.IsNullOrEmpty())
                    {
                        ret.Append(separator);
                        wasAppendedSeparator = true;
                    }
                }
            }

            return wasAppendedSeparator ? ret.ToString().Truncate(ret.Length - separator.Length) : ret.ToString();
        }


        /// <summary>
        /// Join values to one string with separator.
        /// </summary>
        /// <param name="values">Values for join.</param>
        /// <param name="separator">Separator.</param>
        /// <returns>String, which contain joined values with separator.</returns>
        public static string JoinToString(this List<string> values, string separator)
        {
            Contract.Requires(values != null);

            return values.ToArray<object>().JoinToString(separator);
        }


        /// <summary>
        /// Check value is null and then return value or string.Empty.
        /// </summary>
        /// <param name="value">Value which check.</param>
        /// <returns>Value if value is not null, otherwise string.Empty.</returns>
        public static string DefaultIfNull(this string value)
        {
            return value.DefaultIfNull(string.Empty);
        }


        /// <summary>
        /// Check value is null and then return value or defValue.
        /// </summary>
        /// <param name="value">Value which check.</param>
        /// <param name="defValue">Default value if value is null.</param>
        /// <returns>Value if value is not null, otherwise defValue.</returns>
        public static string DefaultIfNull(this string value, string defValue)
        {
            return value == null ? defValue : value;
        }


        /// <summary>
        /// Check if specific email address is valid.
        /// </summary>
        /// <param name="emailAddress">Email address to test.</param>
        /// <returns>true - if address is valid, otherwise false.</returns>
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(emailAddress);
        }


        /// <summary>
        /// Check if specific IP address is valid.
        /// </summary>
        /// <param name="ipAddress">IP address to test.</param>
        /// <returns>true - if address is valid, otherwise false.</returns>
        public static bool IsValidIPAddress(this string ipAddress)
        {
            IPAddress ip;
            if (IPAddress.TryParse(ipAddress, out ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Check if specific URL address is valid.
        /// </summary>
        /// <param name="urlAddress">URL address to test.</param>
        /// <returns>true - if address is valid, otherwise false.</returns>
        public static bool IsValidUrlAddress(this string urlAddress)
        {
            return Uri.IsWellFormedUriString(urlAddress, UriKind.RelativeOrAbsolute);
        }


        /// <summary>
        /// Decode html text to plain text. (Replace Html entities like copy; to ©).
        /// </summary>
        /// <param name="htmlText">Html text.</param>
        /// <returns>Plain text.</returns>
        public static string HtmlDecode(this string htmlText)
        {
            return WebUtility.HtmlDecode(htmlText);
        }

        //ToDo: Later:
        //FormatWithMask
        //Right
        //CountSubString
        //IsDate
    }
}
