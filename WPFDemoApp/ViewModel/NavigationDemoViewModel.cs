using Microsoft.Practices.Unity;
using MMLib.MVVM.Base;
using MMLib.MVVM.Command;
using MMLib.MVVM.Services;
using MMLib.MVVM.ViewModel;
using MMLib.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFDemoApp.ViewModel
{
    /// <summary>
    /// Demo for navigations sample
    /// </summary>
    public class NavigationDemoViewModel : AppMainViewModel, IDemoViewModel, IAppContent
    {

        #region Constructor

        public NavigationDemoViewModel()
        {
            NavigationService.Default = new WPFNavigationServices(new UnityContainer(), this, this);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Display name.
        /// </summary>
        public string DisplayName
        {
            get { return "Navigation demo"; }
        }

        #endregion

        #region Public commands

        private ICommand _showMessageBoxCommand;

        public ICommand ShowMessageBoxCommand
        {
            get
            {
                if (_showMessageBoxCommand == null)
                {
                    _showMessageBoxCommand = new RelayCommand((p) =>
                    {
                        NavigationService.Default.ShowMessageBox("Jeeeeeeeeeeeeeej", eMessageBoxButton.YesNoCancel, eMessageBoxImage.Warning, null);
                    });
                }
                return _showMessageBoxCommand;
            }
        }

        #endregion

        public void OnNavigationIn()
        {
           
        }

        public void OnNavigationOut()
        {

        }
    }
}
