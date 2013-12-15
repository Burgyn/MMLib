using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
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
        /// Truncate string to max lenght. Origin value can by null and Strin.Empty.
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
    }
}
