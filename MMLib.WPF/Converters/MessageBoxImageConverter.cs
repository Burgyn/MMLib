using MMLib.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MMLib.WPF.Converters
{
    /// <summary>
    /// Converter, which convert eMessageBoxImage to image source.
    /// </summary>
    public class MessageBoxImageConverter : IValueConverter
    {

        #region Public methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            eMessageBoxImage val = (eMessageBoxImage)value;

            switch (val)
            {
                case eMessageBoxImage.Error:
                    return Convert(Properties.Resources.Error64);
                case eMessageBoxImage.Question:
                    return Convert(Properties.Resources.Question64);
                case eMessageBoxImage.Warning:
                    return Convert(Properties.Resources.Warning64);
                case eMessageBoxImage.Information:
                    return Convert(Properties.Resources.Information64);
                default:
                    return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Private helpers

        public object Convert(Bitmap value)
        {
            MemoryStream ms = new MemoryStream();

            ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }

        #endregion
    }
}
