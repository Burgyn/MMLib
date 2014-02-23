using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace MMLib.WPF.CustomControls
{
    /// <summary>
    /// Control for displaying date time. For example for chat. Now, 1 min. ago, ....
    /// </summary>
    public class DateTimeMessageControl : Control
    {
        #region Constructor

        static DateTimeMessageControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimeMessageControl),
                new FrameworkPropertyMetadata(typeof(DateTimeMessageControl)));
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// DateTime dependency property.
        /// </summary>
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(
          "DateTime", typeof(DateTime), typeof(DateTimeMessageControl));

        /// <summary>
        /// DateTime property for displaying.
        /// </summary>
        [Description("DateTime property for displaying.")]
        [Category("MMLib.WPF")]
        public DateTime DateTime
        {
            get { return (DateTime)this.GetValue(DateTimeProperty); }
            set { this.SetValue(DateTimeProperty, value); }
        }

        #endregion

        #region Overrides

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if ((DateTime.Now - DateTime).TotalMinutes <= 10)
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
                dispatcherTimer.Start(); 
            }
        }

        #endregion

        #region Private helpers

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var pom = DateTime;
            DateTime = new DateTime();
            DateTime = pom;

            if ((DateTime.Now - DateTime).TotalMinutes > 10)
            {
                (sender as DispatcherTimer).Stop();
                (sender as DispatcherTimer).Tick -= new EventHandler(dispatcherTimer_Tick);
            }
        }

        #endregion
    }
}
