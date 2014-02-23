using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using MMLib.Extensions;
using MMLib.Core.Providers;

namespace MMLib.WPF.Converters
{
    /// <summary>
    /// Converter for converting DateTime value to DateTimeMessage format.
    /// </summary>
    public class DateTimeToMessageCoverter : IValueConverter
    {
        /// <summary>
        /// Converting datetime to datetime message control format.
        /// </summary>
        /// <param name="value">DateTime</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>DateTime message control format of DateTime.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime val = (DateTime)value;
            string ret = Properties.Resources.Now;
            var dateTime = DateTimeProvider.Default;
            var diff = (dateTime.Now - val).TotalMinutes;

            if (val.Date != dateTime.Today || diff > 10)
            {
                if (val.Date != dateTime.Today)
                {
                    if (val.Date.AreInTheSameWeek(dateTime.Today))
                    {
                        ret = val.ToString("ddd H:mm");
                    }
                    else
                    {
                        ret = string.Format("{0}. {1}. {2}", val.ToString("dd"),
                            val.ToString("MMMM").SafeSubstring(3), val.ToString("H:mm"));
                    }
                }
                else
                {
                    ret = val.ToString("H:mm");
                }
            }
            else if (diff >= 1)
            {
                ret = string.Format(Properties.Resources.MinAgo, Math.Round(diff, 0));
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
