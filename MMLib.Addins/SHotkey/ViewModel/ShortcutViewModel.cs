using SearchingKeyboardShortcut;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MMLib.SHotkey.ViewModel
{
    public class ShortcutViewModel : NotificationObject
    {
        #region Private fields

        private bool _searchByShortcut = false;
        private string _searchingString;
        private EnvDTE80.DTE2 _applicationObject;
        private ObservableCollection<VSCommand> _itemsSource;
        private ICollectionView _commandsView;

        #endregion


        public ShortcutViewModel(EnvDTE80.DTE2 dte)
        {
            _applicationObject = dte;
        }

        /// <summary>
        /// Searching by shortcut
        /// </summary>
        public bool SearchByShortcut
        {
            get
            {
                return _searchByShortcut;
            }
            set
            {
                SetPropertyValue<bool>(() => SearchByShortcut, ref _searchByShortcut, value);
            }
        }

        /// <summary>
        /// Searching string
        /// </summary>
        public string SearchingString
        {
            get
            {
                return _searchingString;
            }
            set
            {
                SetPropertyValue<string>(() => SearchingString, ref _searchingString, value);
                _commandsView.Refresh();
            }
        }

        private bool CommandFilter(object item)
        {
            bool ret = true;
            var command = item as VSCommand;

            if (!string.IsNullOrWhiteSpace(this.SearchingString))
            {
                if (this.SearchByShortcut)
                {
                    ret = command.Shortcut.Equals(this.SearchingString, StringComparison.InvariantCultureIgnoreCase);
                }
                else {
                    ret = command.Name.IndexOf(this.SearchingString, 0, StringComparison.InvariantCultureIgnoreCase) >= 0;
                }        
            }
            return ret;
        }


        /// <summary>
        /// Gets the items source.
        /// </summary>
        /// <value>
        /// The items source.
        /// </value>
        public ObservableCollection<VSCommand> ItemsSource
        {
            get
            {
                if (_itemsSource == null)
                {
                    LoadCommands();
                     _commandsView = CollectionViewSource.GetDefaultView(_itemsSource);
                     _commandsView.Filter = CommandFilter;
                }
                return _itemsSource;
            }
        }

        public void OpenSettings()
        {
            _applicationObject.ExecuteCommand("Tools.CustomizeKeyboard");
        }

        public void LoadCommands()
        {
            var ret = new List<VSCommand>();

            List<EnvDTE.Command> commands = GetCommands();

            foreach (EnvDTE.Command command in commands.OrderBy(c => c.Name))
            {
                var bindings = command.Bindings as object[];

                if (bindings != null && bindings.Length > 0)
                {
                    var shortcuts = GetBindings(bindings);

                    foreach (string shortcut in shortcuts)
                    {
                        ret.Add(new VSCommand()
                        {
                            Name = command.Name,
                            Shortcut = shortcut.IndexOf("::") > 0 ? shortcut.Substring(shortcut.IndexOf("::") + 2) : shortcut,
                            Type = shortcut.IndexOf("::") > 0 ? shortcut.Substring(0, shortcut.IndexOf("::")) : string.Empty
                        });
                    }
                }
            }

            _itemsSource = new ObservableCollection<VSCommand>(ret);
        }

        private List<EnvDTE.Command> GetCommands()
        {
            List<EnvDTE.Command> commands = new List<EnvDTE.Command>();

            foreach (EnvDTE.Command command in _applicationObject.Commands)
            {
                if (!string.IsNullOrEmpty(command.Name))
                {
                    commands.Add(command);
                }
            }

            return commands;
        }

        private static IEnumerable<string> GetBindings(IEnumerable<object> bindings)
        {
            var result = bindings.Select(binding => binding.ToString()).Distinct();

            return result;
        }
    }
}
