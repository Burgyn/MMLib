using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MMLib.MVVM.Command
{
    /// <summary>
    /// Class represent command whose purpose is to relay its functionality to other objects.
    /// </summary>
    public class RelayCommand : ICommand
    {

        #region Private Fields

        private Action<object> _execute;
        private Predicate<object> _canExecute;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Execution method delegate.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Execution method delegate.</param>
        /// <param name="canExecute">Function for can execute logic.</param>
        public RelayCommand(Action<object> execute,
                         Predicate<object> canExecute)
        {
            Contract.Requires(execute != null);

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Display name of the command.
        /// </summary>
        public string DisplayName { get; set; }

        #endregion

        #region ICommand Members

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
            return _canExecute == null ? true : _canExecute(parameter);
        }


        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        public void Execute()
        {
            OnExecute(null);
        }


        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            OnExecute(parameter);
        }

        #endregion


        #region Protected

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        protected virtual void OnExecute(object parameter)
        {
            if (this.CanExecute(parameter))
            {
                _execute(parameter); 
            }
        }


        #endregion


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
    }
}
