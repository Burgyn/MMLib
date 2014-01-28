using Microsoft.Practices.Unity;
using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Services
{
    /// <summary>
    /// Navigation service, which know navigate through application
    /// </summary>
    public class NavigationService : INavigationService
    {
        #region private fields

        private UnityContainer _conainer;
        private IAppMainViewModel _appMainViewModel;
        private IAppContent _appHomeContent;
        private Stack<IAppContent> _navigationHistory = new Stack<IAppContent>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Unity container for resolving navigation targets.</param>
        /// <param name="appMainViewModel">Main application view model.</param>
        /// <param name="appHomeContent">Application home content.</param>
        public  NavigationService(UnityContainer container,
                               IAppMainViewModel appMainViewModel,
                                     IAppContent appHomeContent)
        {
            Contract.Requires(container != null);
            Contract.Requires(appMainViewModel != null);
            Contract.Requires(appHomeContent != null);

            _conainer = container;
            _appMainViewModel = appMainViewModel;
            _appHomeContent = appHomeContent;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Default navigation services
        /// </summary>
        public static INavigationService Default { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Navigate to specific target type.
        /// </summary>
        /// <param name="target">Type of target content.</param>
        public void NavigateTo(Type target)
        {
            Contract.Requires(target != null);

            NavigateTo(_conainer.Resolve(target) as IAppContent);
        }

        /// <summary>
        /// Navigate to target content.
        /// </summary>
        /// <param name="target">Navigate to new target appliaction content.</param>
        public virtual void NavigateTo(IAppContent target)
        {
            Contract.Requires(target != null);

            CheckHistory(target);
            OnNavigateTo(target);
        }

        /// <summary>
        /// Navigate to home content.
        /// </summary>
        public void NavigateHome()
        {
            OnNavigateTo(_appHomeContent);
        }

        /// <summary>
        /// Navigate to preview content.
        /// </summary>
        public void NavigateBack()
        {
            if (CanNavigateBack())
            {
                var target = _navigationHistory.Pop();
                OnNavigateTo(target);
            }
            else
            {
                throw new InvalidOperationException("Cannot call Navigate back method, when CanNavigateBack return false.");
            }
        }

        /// <summary>
        /// Can navigate to preview content?
        /// </summary>
        /// <returns>Can navigate to preview content?</returns>
        public bool CanNavigateBack()
        {
            return _navigationHistory.Count > 0;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Navigate to target content.
        /// </summary>
        /// <param name="target">Navigate to new target appliaction content.</param>
        protected virtual void OnNavigateTo(IAppContent target)
        {
            _appMainViewModel.AppContent = target;
        }

        #endregion

        #region Private helpers

        private void CheckHistory(IAppContent target)
        {
            if (_appMainViewModel.AppContent != null && target != _appHomeContent)
            {
                _navigationHistory.Push(_appMainViewModel.AppContent);
            }
            else
            {
                _navigationHistory.Clear();
            }
        }

        #endregion
    }
}
