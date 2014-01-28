using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// Base class for app main view model.
    /// </summary>
    public class AppMainViewModel : BaseViewModel, IAppMainViewModel
    {
        #region Private Fields

        private IAppContent _appContent;

        #endregion

        #region Public properties

        /// <summary>
        /// Actual application content
        /// </summary>
        public IAppContent AppContent
        {
            get
            {
                return _appContent;
            }
            set
            {
                SetPropertyValue<IAppContent>(() => AppContent, ref _appContent, value);
            }
        }

        #endregion
    }
}
