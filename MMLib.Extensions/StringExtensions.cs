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
    }
}
