using MMLib.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoApp.ViewModel
{
    public class DemoAppViewModel : NotificationObject
    {
        #region Private Fields

        private IDemoViewModel _actualDemo;

        #endregion

        #region Public

        public DemoAppViewModel()
        {
            ItemsSource = new ObservableCollection<IDemoViewModel>();
            ItemsSource.Add(new DateTimeControlDemoVM());

            ActualDemo = ItemsSource[0];
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Items source of all demo view models.
        /// </summary>
        public ObservableCollection<IDemoViewModel> ItemsSource { get; set; }
       
        /// <summary>
        /// Actual demo.
        /// </summary>
        public IDemoViewModel ActualDemo
        {
            get
            {
                return _actualDemo;
            }
            set
            {
                SetPropertyValue<IDemoViewModel>(() => ActualDemo, ref _actualDemo, value);
            }
        }

        #endregion
    }
}
