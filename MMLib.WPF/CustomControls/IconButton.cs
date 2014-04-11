using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// Button, which display image as content
    /// </summary>
    public class IconButton : Button
    {
        /// <summary>
        /// Source for Image
        /// </summary>
        public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(IconButton));

        /// <summary>
        /// Source for image
        /// </summary>
        [Description("ImageSource for Image")]
        [Category("MMLib.WPF")]
        public ImageSource ImageSource
        {
            get
            {
                return ((ImageSource)(base.GetValue(IconButton.ImageSourceProperty)));
            }
            set
            {
                base.SetValue(IconButton.ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Image width
        /// </summary>
        public static DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(IconButton));

        /// <summary>
        /// Image width
        /// </summary>
        [Description("Image width")]
        [Category("MMLib.WPF")]        
        public double ImageWidth
        {
            get
            {
                return ((double)(base.GetValue(IconButton.ImageWidthProperty)));
            }
            set
            {
                base.SetValue(IconButton.ImageWidthProperty, value);
            }
        }

        /// <summary>
        /// Button background, when mouse is over.
        /// </summary>
        public static DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(IconButton));

        /// <summary>
        ///  Button background, when mouse is over.
        /// </summary>
        [Description("Background, when mouse is over button")]
        [Category("MMLib.WPF")]
        public Brush MouseOverBackground
        {
            get
            {
                return ((Brush)(base.GetValue(IconButton.MouseOverBackgroundProperty)));
            }
            set
            {
                base.SetValue(IconButton.MouseOverBackgroundProperty, value);
            }
        }
    }
}
