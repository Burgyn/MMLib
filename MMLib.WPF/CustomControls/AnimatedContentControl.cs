using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// A ContentControl that animates the transition between content
    /// </summary>
    [TemplatePart(Name = "PART_PaintArea", Type = typeof(Shape)),
     TemplatePart(Name = "PART_MainContent", Type = typeof(ContentPresenter))]
    public class AnimatedContentControl : ContentControl
    {
        #region Private Fields

        private Shape _paintArea;
        private ContentPresenter _mainContent;

        #endregion

        #region Constructor

        static AnimatedContentControl()
        {
            SlideDirection = SlidingDirection.FromRightToLeft;
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedContentControl), new FrameworkPropertyMetadata(typeof(AnimatedContentControl)));
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Direction of content animate.
        /// </summary>
        public static AnimatedContentControl.SlidingDirection SlideDirection { get; set; }

        /// <summary>
        /// Animation Amplitude
        /// </summary>
        public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register(
          "Amplitude", typeof(double), typeof(AnimatedContentControl), new PropertyMetadata(0.5));

        /// <summary>
        /// Animation durration
        /// </summary>
        [Description("Amplitude of the animation")]
        [Category("MMLib.WPF")]
        public double Amplitude
        {
            get { return (double)this.GetValue(AmplitudeProperty); }
            set { this.SetValue(AmplitudeProperty, value); }
        }

        /// <summary>
        /// Animation durration
        /// </summary>
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
          "Duration", typeof(double), typeof(AnimatedContentControl), new PropertyMetadata(0.5));

        /// <summary>
        /// Animation durration
        /// </summary>
        [Description("Duration of the animation")]
        [Category("MMLib.WPF")]
        public double Duration
        {
            get { return (double)this.GetValue(DurationProperty); }
            set { this.SetValue(DurationProperty, value); }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// This gets called when the template has been applied and we have our visual tree
        /// </summary>
        public override void OnApplyTemplate()
        {
            _paintArea = Template.FindName("PART_PaintArea", this) as Shape;
            _mainContent = Template.FindName("PART_MainContent", this) as ContentPresenter;

            base.OnApplyTemplate();
        }

        /// <summary>
        /// This gets called when the content we're displaying has changed
        /// </summary>
        /// <param name="oldContent">The content that was previously displayed</param>
        /// <param name="newContent">The new content that is displayed</param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (_paintArea != null && _mainContent != null)
            {
                _paintArea.Fill = CreateBrushFromVisual(_mainContent);
                BeginAnimateContentReplacement();
            }
            base.OnContentChanged(oldContent, newContent);
        }


        #endregion

        #region Private helpers

        /// <summary>
        /// Starts the animation for the new content
        /// </summary>
        private void BeginAnimateContentReplacement()
        {
            var newContentTransform = new TranslateTransform();
            var oldContentTransform = new TranslateTransform();
            _paintArea.RenderTransform = oldContentTransform;
            _mainContent.RenderTransform = newContentTransform;
            _paintArea.Visibility = Visibility.Visible;

            newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(DirectionForNewContent()));
            oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(DirectionForOldContent(),
                (s, e) => _paintArea.Visibility = Visibility.Hidden));
        }

        private AnimationTimeline CreateAnimation(FromTo fromTo, EventHandler whenDone = null)
        {
            IEasingFunction ease = new BackEase { Amplitude = Amplitude, EasingMode = EasingMode.EaseOut };
            var duration = new Duration(TimeSpan.FromSeconds(Duration));
            var anim = new DoubleAnimation(fromTo.From, fromTo.To, duration) { EasingFunction = ease };
            if (whenDone != null)
                anim.Completed += whenDone;
            anim.Freeze();
            return anim;
        }

        /// <summary>
        /// Creates a brush based on the current appearnace of a visual element. The brush is an ImageBrush and once created, won't update its look
        /// </summary>
        /// <param name="v">The visual element to take a snapshot of</param>
        private Brush CreateBrushFromVisual(Visual v)
        {
            if (v == null)
                throw new ArgumentNullException("v");
            var target = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            target.Render(v);
            var brush = new ImageBrush(target);
            brush.Freeze();
            return brush;
        }

        private FromTo DirectionForNewContent()
        {
            FromTo ret = null;

            if (AnimatedContentControl.SlideDirection == SlidingDirection.FromRightToLeft)
            {
                ret = new FromTo() { From = this.ActualWidth, To = 0 };
            }
            else
            {
                ret = new FromTo() { From = -this.ActualWidth, To =  0};
            }

            return ret;
        }

        private FromTo DirectionForOldContent()
        {
            FromTo ret = null;

            if (AnimatedContentControl.SlideDirection == SlidingDirection.FromRightToLeft)
            {
                ret = new FromTo() { From = 0, To = -this.ActualWidth };
            }
            else
            {
                ret = new FromTo() { From = 0, To = this.ActualWidth };
            }

            return ret;
        }

        #endregion

        #region Helpers

        private class FromTo
        {
            public double From { get; set; }
            public double To { get; set; }
        }

        /// <summary>
        /// Enum represent direction of content animation.
        /// </summary>
        public enum SlidingDirection
        {
            /// <summary>
            /// Animate from left to right.
            /// </summary>
            FromLeftToRight,
            /// <summary>
            /// Animate from right to left.
            /// </summary>
            FromRightToLeft,
        }

        #endregion
    }
}
