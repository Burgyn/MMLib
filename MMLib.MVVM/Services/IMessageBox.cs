using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Services
{
    /// <summary>
    /// Interface, which describe message box.
    /// </summary>
    public interface IMessageBox
    {

        /// <summary>
        /// Message for shown in messagebox.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Buttons, which want show.
        /// </summary>
        eMessageBoxButton Buttons { get; }

        /// <summary>
        /// Image.
        /// </summary>
        eMessageBoxImage Image { get; }

        /// <summary>
        /// Callback function, which is called after user click on button.
        /// </summary>
        Action<eMessageBoxResult> CallBack { get; }
    }
}
