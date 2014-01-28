using Microsoft.Practices.Unity;
using MMLib.MVVM.Command;
using MMLib.MVVM.Services;
using MMLib.MVVM.ViewModel;
using MMLib.WPF.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MMLib.WPF.Services
{
    /// <summary>
    /// Class which represent WPF navigation services.
    /// </summary>
    public class WPFNavigationServices : NavigationService
    {

        #region Private Fields

        private ICommand _navigateToCommand;
        private ICommand _navigateBackCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Unity container for resolving navigation targets.</param>
        /// <param name="appMainViewModel">Main application view model.</param>
        /// <param name="appHomeContent">Application home content.</param>
        public WPFNavigationServices(UnityContainer container,
                               IAppMainViewModel appMainViewModel,
                                     IAppContent appHomeContent)
            : base(container, appMainViewModel, appHomeContent)
        {
            NavigationService.Default = this;
        }

        #endregion

        #region Public commands

        /// <summary>
        /// Command for navigation to target.
        /// </summary>
        public ICommand NavigateToCommand
        {
            get
            {
                if (_navigateToCommand == null)
                {
                    _navigateToCommand = new RelayCommand((p) =>
                    {                        
                        NavigateTo(p as IAppContent);
                    });
                }
                return _navigateToCommand;
            }
        }
        
        /// <summary>
        /// Command for navigation to back.
        /// </summary>
        public ICommand NavigateBackCommand
        {
            get
            {
                if (_navigateBackCommand == null)
                {
                    _navigateBackCommand = new RelayCommand((p) =>
                    {
                        AnimatedContentControl.SlideDirection = AnimatedContentControl.SlidingDirection.FromLeftToRight;
                        NavigateBack();
                    }, p => { return CanNavigateBack(); });
                }
                return _navigateBackCommand;
            }
        }

        #endregion

        #region Public overrides

        /// <summary>
        /// Navigate to target content.
        /// </summary>
        /// <param name="target">Navigate to new target appliaction content.</param>
        public override void NavigateTo(IAppContent target)
        {
            AnimatedContentControl.SlideDirection = AnimatedContentControl.SlidingDirection.FromRightToLeft;
            base.NavigateTo(target);
        }

        #endregion
    }
}
