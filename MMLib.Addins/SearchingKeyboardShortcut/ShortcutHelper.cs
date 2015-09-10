using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingKeyboardShortcut
{
    public class ShortcutHelper
    {
        private EnvDTE80.DTE2 _applicationObject;
        private IList<VSCommand> _commands;


        public ShortcutHelper(EnvDTE80.DTE2 dte)
        {
            _applicationObject = dte;
        }

        public IList<VSCommand> GetVSCommands()
        {
            if (_commands == null)
            {
                _commands = new List<VSCommand>();

                List<Command> commands = GetCommands();

                foreach (EnvDTE.Command command in commands.OrderBy(c => c.Name))
                {
                    var bindings = command.Bindings as object[];

                    if (bindings != null && bindings.Length > 0)
                    {
                        var shortcuts = GetBindings(bindings);

                        foreach (string shortcut in shortcuts)
                        {
                            _commands.Add(new VSCommand()
                            {
                                Name = command.Name,
                                Shortcut = shortcut.IndexOf("::") > 0 ? shortcut.Substring(shortcut.IndexOf("::") + 2) : shortcut,
                                Type = shortcut.IndexOf("::") > 0 ? shortcut.Substring(0, shortcut.IndexOf("::")) : string.Empty
                            });
                        }
                    }
                }
            }

            return _commands;
        }

        /// <summary>
        /// Gets the commands by command name.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <returns>Commands, whitch name is match with specific name.</returns>
        public IEnumerable<VSCommand> GetCommandsByName(string commandName)
        {
            commandName = commandName.Replace(" ", string.Empty);            
            var commands =  GetVSCommands().Where(p => p.Name.IndexOf(commandName, 0, StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();

            return commands;
        }

        /// <summary>
        /// Gets the commands by shortcut.
        /// </summary>
        /// <param name="shortcut">The shortcut.</param>
        /// <returns></returns>
        public IEnumerable<VSCommand> GetCommandsByShortcut(string shortcut)
        {
            var commands = GetVSCommands().Where(p => p.Shortcut.Equals(shortcut, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return commands;
        }

        public Int32 CommandCount()
        {
            return GetVSCommands().Count;
        }

        private List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>();

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
