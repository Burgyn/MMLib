using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MMLib.Core.Providers
{
    /// <summary>
    /// Process provider, which represent System.Diagnostics.Process.
    /// We can change default provider to your custom IProcessProvider.
    /// </summary>
    public class ProcessProvider : IProcessProvider
    {

        #region Private Fields

        private Process _currentProcess;
        private static IProcessProvider _instance;

        #endregion

        #region Constructor

        private ProcessProvider(Process process)
        {
            _currentProcess = process;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the unique identifier for the associated process
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///  The process's System.Diagnostics.Process.Id property has not been set.-or-
        ///  There is no process associated with this System.Diagnostics.Process object.
        /// </exception>
        /// <exception cref="System.PlatformNotSupportedException">
        /// The platform is Windows 98 or Windows Millennium Edition (Windows Me); set
        /// System.Diagnostics.ProcessStartInfo.UseShellExecute to false to access this
        /// property on Windows 98 and Windows Me.
        /// </exception>
        public int Id
        {
            get
            {
                return _currentProcess.Id;
            }
        }

        /// <summary>
        /// Gets the full path to the main module.
        /// </summary>
        public string MainModuleFileName
        {
            get
            {
                return _currentProcess.MainModule.FileName;
            }
        }


        /// <summary>
        /// Gets the name that the system uses to identify the process to the user.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// The process does not have an identifier, or no process is associated with
        /// the System.Diagnostics.Process.-or- The associated process has exited.
        /// </exception>
        /// <exception cref="System.PlatformNotSupportedException">
        /// The platform is Windows 98 or Windows Millennium Edition (Windows Me); set
        /// System.Diagnostics.ProcessStartInfo.UseShellExecute to false to access this
        /// property on Windows 98 and Windows Me.
        /// </exception>
        /// <exception cref="NotSupportedException">The process is not on this computer.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [MonitoringDescription("ProcessProcessName")]
        public string ProcessName
        {
            get
            {
                return _currentProcess.ProcessName;
            }
        }

        /// <summary>
        /// Default IProcessProvider.
        /// </summary>
        public static IProcessProvider Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProcessProvider(Process.GetCurrentProcess());
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process.
        /// </summary>
        /// <returns>
        /// IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process
        /// </returns>
        public IProcessProvider GetCurrentProcess()
        {
            return this;
        }

        /// <summary>
        /// Creates an array of new IProcessProviders components associated
        /// with all the process resources on the local computer that share the
        /// specified process name.
        /// </summary>
        /// <param name="processName">The friendly name of the process.</param>
        /// <returns>
        /// An array of new IProcessProviders components associated
        /// with all the process resources on the local computer that share the
        /// specified process name.
        /// </returns>
        public IProcessProvider[] GetProcessesByName(string processName)
        {
            return Process.GetProcessesByName(processName).Select(p => new ProcessProvider(p)).ToArray();
        }

        #endregion
    }
}
