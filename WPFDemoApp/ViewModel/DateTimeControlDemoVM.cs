using MMLib.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoApp.ViewModel
{
    /// <summary>
    /// View model for DateTime control demo.
    /// </summary>
    public class DateTimeControlDemoVM : NotificationObject, IDemoViewModel
    {
        #region Constructor

        public DateTimeControlDemoVM()
        {
            ItemsSource = new ObservableCollection<DateTime>();

            ItemsSource.Add(DateTime.Now);
            ItemsSource.Add(DateTime.Now.AddMinutes(-1));
            ItemsSource.Add(DateTime.Now.AddMinutes(-2));
            ItemsSource.Add(DateTime.Now.AddMinutes(-5));
            ItemsSource.Add(DateTime.Now.AddMinutes(-9));

            ItemsSource.Add(DateTime.Now.AddHours(-1));
            ItemsSource.Add(DateTime.Now.AddDays(-1));
            ItemsSource.Add(DateTime.Now.AddDays(-10));
        }

        #endregion

        #region Public properties

        /// <summary>
        /// ItemsSource with DateTime.
        /// </summary>
        public ObservableCollection<DateTime> ItemsSource { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName
        {
            get { return "DateTime message control"; }
        }

        #endregion

        #region Public methods

        public override string ToString()
        {
            return DisplayName;
        }

        #endregion
    }
}
