using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.Core.Providers.Fakes
{
    /// <summary>
    /// Fake process provider for testing.
    /// </summary>
    public class FakeProcessProvider : IProcessProvider
    {
        #region Private Fields

        private IEnumerable<KeyValuePair<string, string>> _processes;

        #endregion

        #region Constructors

        public FakeProcessProvider(IEnumerable<KeyValuePair<string, string>> processes)
        {
            _processes = processes;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the full path to the main module.
        /// </summary>
        public string MainModuleFileName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name that the system uses to identify the process to the user.
        /// </summary>
        public string ProcessName
        {
            get;
            set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets fake IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process.
        /// </summary>
        /// <returns>
        /// Fake IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process
        /// </returns>
        public IProcessProvider GetCurrentProcess()
        {
            return this;
        }

        /// <summary>
        /// Creates an array of new fake IProcessProviders.
        /// </summary>
        /// <param name="processName">The friendly name of the process.</param>
        /// <returns>
        /// An array of new IProcessProviders components associated
        /// with all the process resources on the local computer that share the
        /// specified process name.
        /// </returns>
        public IProcessProvider[] GetProcessesByName(string processName)
        {
            return _processes.Where(p => p.Key == processName).Select(p => new FakeProcessProvider(null)
            {
                MainModuleFileName = p.Value,
                ProcessName = p.Key
            }).ToArray();
        }

        #endregion

    }
}
