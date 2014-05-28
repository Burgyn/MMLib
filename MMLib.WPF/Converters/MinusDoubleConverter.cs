using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MMLib.WPF.Converters
{
    /// <summary>
    /// Converter, which convert double value to double minus specific value.
    /// </summary>
    public class MinusDoubleConverter : IValueConverter
    {
        /// <summary>
        /// Convert double value to double minus specific value (converter parameter).
        /// </summary>
        /// <param name="value">Oreginal double value.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Double value, which specified value which we want remove from oreginal value.</param>        
        /// <param name="culture"></param>
        /// <returns>Double value minus parameter value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Contract.Requires(value != null);
            Contract.Requires(targetType != null);

            double oreginalValue = (double)value;
            double parameterValue = (double)parameter;

            double ret = oreginalValue - parameterValue;

            return ret >= 0 ? ret : 0;
        }

        /// <summary>
        /// NotImplementedException.
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
