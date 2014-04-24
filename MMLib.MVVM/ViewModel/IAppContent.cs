using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// Interface for application content, which can be shown in application.
    /// </summary>
    public interface IAppContent
    {
        /// <summary>
        /// Occured, when navigation service navigate to this content.
        /// </summary>
        void OnNavigationIn();

        /// <summary>
        /// Occured, when navigation service navigate to another content from this content.
        /// </summary>
        void OnNavigationOut();
    }
}
