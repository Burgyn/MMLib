using MMLib.MVVM.Base;
using MMLib.MVVM.Command;
using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Services
{
    /// <summary>
    /// Class, which represent messagebox
    /// </summary>
    public class MessageBox : NotificationObject, IMessageBox
    {
        #region Private Fields

        private IAppMainViewModel _appMainViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appMainViewModel">Main app view model.</param>
        private MessageBox(IAppMainViewModel appMainViewModel)
        {
            _appMainViewModel = appMainViewModel;

            Commands = new List<RelayCommand>();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Message for shown in messagebox.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Buttons, which want show.
        /// </summary>
        public eMessageBoxButton Buttons { get; private set; }

        /// <summary>
        /// Image.
        /// </summary>
        public eMessageBoxImage Image { get; private set; }

        /// <summary>
        /// Callback function, which is called after user click on button.
        /// </summary>
        public Action<eMessageBoxResult> CallBack { get; private set; }

        /// <summary>
        /// Commands.
        /// </summary>
        public IList<RelayCommand> Commands { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Create instance of IMessageBox.
        /// </summary>
        /// <param name="appMainViewModel">Main app view model.</param>
        /// <param name="message">Message to show.</param>
        /// <param name="buttons">Buttons, which want show.</param>
        /// <param name="images">Image.</param>
        /// <param name="callBack">Callback function, which is called after user click on button.</param>
        /// <returns>
        /// IMesageBox instance.
        /// </returns>
        public static IMessageBox CreateMessageBox(IAppMainViewModel appMainViewModel,
                                                              string message,
                                                   eMessageBoxButton buttons,
                                                    eMessageBoxImage images,
                                           Action<eMessageBoxResult> callBack)
        {
            var ret = new MessageBox(appMainViewModel)
            {
                Message = message,
                Buttons = buttons,
                Image = images,
                CallBack = callBack
            };

            InitButtons(buttons, ret);

            return ret;
        }

        #endregion

        #region Private helpers

        private void Close(eMessageBoxResult result)
        {
            _appMainViewModel.MessageBox = null;
            if (CallBack != null)
            {
                CallBack(result);
            }
        }

        private static void InitButtons(eMessageBoxButton buttons, MessageBox ret)
        {
            switch (buttons)
            {
                case eMessageBoxButton.OK:
                case eMessageBoxButton.OKCancel:
                    ret.Commands.Add(new RelayCommand(p => ret.Close(eMessageBoxResult.OK))
                    {
                        DisplayName = "ok"
                    });
                    if (buttons == eMessageBoxButton.OKCancel)
                    {
                        ret.Commands.Add(new RelayCommand(p => ret.Close(eMessageBoxResult.Cancel))
                        {
                            DisplayName = "cancel"
                        });
                    }
                    break;

                case eMessageBoxButton.YesNo:
                case eMessageBoxButton.YesNoCancel:
                    ret.Commands.Add(new RelayCommand(p => ret.Close(eMessageBoxResult.Yes))
                    {
                        DisplayName = "yes"
                    });
                    ret.Commands.Add(new RelayCommand(p => ret.Close(eMessageBoxResult.No))
                    {
                        DisplayName = "no"
                    });
                    if (buttons == eMessageBoxButton.YesNoCancel)
                    {
                        ret.Commands.Add(new RelayCommand(p => ret.Close(eMessageBoxResult.Cancel))
                        {
                            DisplayName = "ok"
                        });
                    }
                    break;
            }
        }

        #endregion
    }
}
