using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MMLib.WPF.Converters
{
    public class DateTimeToMessageCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime val = (DateTime)value;
            string ret = "teraz";

            if (val.Date != DateTime.Today || (DateTime.Now - val).TotalMinutes > 5)
            {
                if (val.Date != DateTime.Today)
                {
                    ret = val.ToString();
                }
                else
                {
                    ret = val.ToString("HH:mm");
                }
            }
            else if ((DateTime.Now - val).TotalMinutes > 0)
            {
                ret = string.Format("pred {0} min.", Math.Round((DateTime.Now - val).TotalMinutes, 0));
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
