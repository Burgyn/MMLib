using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Services
{
    /// <summary>
    ///  Specifies the buttons that are displayed on a message box.
    /// </summary>
    public enum eMessageBoxButton
    {
        /// <summary>
        /// The message box displays an OK button.
        /// </summary>
        OK = 0,

        /// <summary>
        /// The message box displays OK and Cancel buttons.
        /// </summary>
        OKCancel = 1,

        /// <summary>
        /// The message box displays Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel = 3,
     
        /// <summary>
        /// The message box displays Yes and No buttons.
        /// </summary>
        YesNo = 4,
    }

    /// <summary>
    /// Specifies the icon that is displayed by a message box.
    /// </summary>
    public enum eMessageBoxImage
    {
        /// <summary>
        /// No icon is displayed.
        /// </summary>
        None = 0,

        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with
        /// a red background.
        /// </summary>
        Error = 16,

        /// <summary>
        /// The message box contains a symbol consisting of a question mark in a circle.
        /// </summary>
        Question = 32,

        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a
        /// triangle with a yellow background.
        /// </summary>
        Warning = 48,

        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a
        /// circle.
        /// </summary>
        Information = 64,
    }

    /// <summary>
    /// Specifies which message box button that a user clicks. System.Windows.MessageBoxResult
    /// is returned by the Overload:System.Windows.MessageBox.Show method.
    /// </summary>
    public enum eMessageBoxResult
    {
        /// <summary>
        /// The result value of the message box is OK.
        /// </summary>
        OK = 1,

        /// <summary>
        /// The result value of the message box is Cancel.
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// The result value of the message box is Yes.
        /// </summary>
        Yes = 6,

        /// <summary>
        /// The result value of the message box is No.
        /// </summary>
        No = 7,
    }
}
