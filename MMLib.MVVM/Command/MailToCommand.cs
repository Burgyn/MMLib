using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MMLib.MVVM.Command
{
    /// <summary>
    /// Command, which open default mail client with specific address.
    /// </summary>
    public class MailToCommand : ICommand
    {
        #region ICommand Members

        /// <summary>
        /// Eventa či je možné vykonať akciu.
        /// <para>
        /// Toto si volá WPF samé.
        /// </para>
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, his object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString());
        }


        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var url = string.Format("mailto:{0}", parameter);
                Process.Start(url);
            }
        }

        #endregion
    }
}
