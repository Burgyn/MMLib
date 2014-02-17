using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MMLib.Extensions;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// A helper class that provides various attached properties for the TextBox control.
    /// </summary>
    public class TextBoxHelper
    {

        #region Private Fields

        private static Dictionary<TextBlock, IEmoticonsConverter> _emoticonsConverters = new Dictionary<TextBlock, IEmoticonsConverter>();
        private static object _lock = new object();

        #endregion

        /// <summary>
        /// Attached property for emoticons converter.
        /// </summary>
        public static readonly DependencyProperty EmoticonsConverterProperty =
            DependencyProperty.RegisterAttached("EmoticonsConverter", typeof(IEmoticonsConverter), typeof(TextBox),
            new FrameworkPropertyMetadata(null, EmoticonsConverterChanged));

        /// <summary>
        /// Get part of Dependency property/
        /// </summary>
        public static IEmoticonsConverter GetEmoticonsConverter(DependencyObject obj)
        {
            return (IEmoticonsConverter)obj.GetValue(EmoticonsConverterProperty);
        }

        /// <summary>
        /// Set part of Dependency property/
        /// </summary>
        public static void SetEmoticonsConverter(DependencyObject obj,
                                              IEmoticonsConverter value)
        {
            obj.SetValue(EmoticonsConverterProperty, value);
        }

        private static void EmoticonsConverterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                textBlock.Loaded -= textbox_Loaded;
                if (e.NewValue != null)
                {
                    lock (_lock)
                    {
                        _emoticonsConverters.Add(textBlock, e.NewValue as IEmoticonsConverter);
                    }
                    textBlock.Loaded += textbox_Loaded;
                }
                else
                {
                    lock (_lock)
                    {
                        _emoticonsConverters.Remove(textBlock);
                    }
                }
            }
        }

        private static void textbox_Loaded(object sender, RoutedEventArgs e)
        {
            var textBlock = sender as TextBlock;
            textBlock.Loaded -= textbox_Loaded;
            IEmoticonsConverter emoticonsConverter = null;

            lock (_lock)
            {
                emoticonsConverter = _emoticonsConverters[textBlock];
                _emoticonsConverters.Remove(textBlock);
            }

            var text = textBlock.Text;
            textBlock.Inlines.Clear();
            while (text.Contains(":-)"))
            {
                textBlock.Inlines.Add(new Run(text.Substring(0, text.IndexOf(":-)"))));
                text = text.Substring(text.IndexOf(":-)") + 3);
                var image = new Image()
                {
                    Source = Emoticon(),
                    Stretch = System.Windows.Media.Stretch.UniformToFill,
                    Width = textBlock.FontSize,
                    Height = textBlock.FontSize
                };
                RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
                textBlock.Inlines.Add(new InlineUIContainer(image));
            }

            if (!text.IsNullOrEmpty())
            {
                textBlock.Inlines.Add(new Run(text));
            }

            //var text = textBlock.Text;
            //textBlock.Inlines.Clear();
            //IList<string> sb = new List<string>();
            //foreach (string word in text.SplitBySeparator(" "))
            //{
            //    if (emoticonsConverter.IsEmoticonAlias(word))
            //    {
            //        if (sb.Count > 0)
            //        {
            //            textBlock.Inlines.Add(new Run(sb.ToArray().JoinToString(" ")));
            //        }
            //        sb = new List<string>();
            //        var image = new Image()
            //        {
            //            Source = emoticonsConverter.Emoticon(word),
            //            Stretch = System.Windows.Media.Stretch.UniformToFill,
            //            Width = textBlock.FontSize,
            //            Height = textBlock.FontSize
            //        };
            //        RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            //        textBlock.Inlines.Add(new InlineUIContainer(image));

            //    }
            //    else
            //    {
            //        sb.Add(word);
            //    }
            //}

            //if (sb.Count > 0)
            //{
            //    textBlock.Inlines.Add(new Run(sb.ToArray().JoinToString(" ")));
            //}
        }

        private void Neviem(TextBlock textblock, string text, IEmoticonsConverter converter) { }

        public static BitmapImage Emoticon()
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
