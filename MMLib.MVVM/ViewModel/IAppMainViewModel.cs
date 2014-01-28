using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// Interface which describe main view model of application.
    /// </summary>
    public interface IAppMainViewModel
    {
        /// <summary>
        /// Actual application content.
        /// </summary>
        IAppContent AppContent { get; set; }
    }
}
