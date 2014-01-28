using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MMLib.MVVM.Services
{
    /// <summary>
    /// Interface for navigation service, which know navigate through application.
    /// </summary>
    public interface INavigationService
    {        
        /// <summary>
        /// Navigate to specific target type.
        /// </summary>
        /// <param name="target">Type of target content.</param>
        void NavigateTo(Type target);

        /// <summary>
        /// Navigate to target content.
        /// </summary>
        /// <param name="target">Navigate to new target appliaction content.</param>
        void NavigateTo(IAppContent target);

        /// <summary>
        /// Navigate to home content.
        /// </summary>
        void NavigateHome();

        /// <summary>
        /// Navigate to preview content.
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// Can navigate to preview content?
        /// </summary>
        /// <returns>Can navigate to preview content?</returns>
        bool CanNavigateBack();
    }
}
