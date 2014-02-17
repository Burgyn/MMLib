using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// Interface, which describe interface for string to emoticon converter.
    /// </summary>
    public interface IEmoticonsConverter
    {
        /// <summary>
        /// Can text consider as emoticon alias?
        /// </summary>
        /// <param name="text">Testing text.</param>
        /// <returns>true - if text is alias for emoticon; otherwise false.</returns>
        bool IsEmoticonAlias(string text);

        /// <summary>
        /// Get emoticon for emoticon text alias.
        /// </summary>
        /// <param name="text">Text alias for emoticon.</param>
        /// <returns>
        /// Emoticon, which represent text.
        /// </returns>
        BitmapImage Emoticon(string text);
    }
}
