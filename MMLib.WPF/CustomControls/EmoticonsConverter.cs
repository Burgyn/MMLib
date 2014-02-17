using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// Converter, which know convert text to emoticon.
    /// </summary>
    public class EmoticonsConverter : IEmoticonsConverter
    {
        /// <summary>
        /// Can text consider as emoticon alias?
        /// </summary>
        /// <param name="text">Testing text.</param>
        /// <returns>true - if text is alias for emoticon; otherwise false.</returns>
        public bool IsEmoticonAlias(string text)
        {
            return text == ":-)";
        }

        /// <summary>
        /// Get emoticon for emoticon text alias.
        /// </summary>
        /// <param name="text">Text alias for emoticon.</param>
        /// <returns>
        /// Emoticon, which represent text.
        /// </returns>
        public BitmapImage Emoticon(string text)
        {
            BitmapImage img = new BitmapImage();

            MemoryStream memory = new MemoryStream();
            Properties.Resources.smile.Save(memory, ImageFormat.Png);
            memory.Position = 0;
            img.BeginInit();
            img.StreamSource = memory;
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();

            return img;
        }
    }
}
