using MMLib.MVVM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// Base class for ViewModel.
    /// </summary>
    public abstract class BaseViewModel : NotificationObject
    {
        #region Private Fields

        private static bool? _isInDesignMode;

        #endregion

        #region Public properties

        /// <summary>
        /// Is View model call in Design time?
        /// </summary>
        public static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode
                        = (bool)DependencyPropertyDescriptor
                                     .FromProperty(prop, typeof(FrameworkElement))
                                     .Metadata.DefaultValue;

                    if (!_isInDesignMode.Value
                        && Process.GetCurrentProcess().ProcessName.StartsWith("devenv", StringComparison.Ordinal))
                    {
                        _isInDesignMode = true;
                    }
                }

                return _isInDesignMode.Value;
            }
        }


        #endregion
    }
}
