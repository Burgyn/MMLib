using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MMLib.Core.Providers
{
    /// <summary>
    /// Interface for ProcessProvider, which represent System.Diagnostics.Process
    /// </summary>
    public interface IProcessProvider
    {
        /// <summary>
        /// Gets new IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process.
        /// </summary>
        /// <returns>
        /// New IProcessProvider which represent System.Diagnostics.Process component 
        /// associated with the currently active process
        /// </returns>
        IProcessProvider GetCurrentProcess();

        /// <summary>
        /// Gets the full path to the main module.
        /// </summary>
        string MainModuleFileName { get;}

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
        IProcessProvider[] GetProcessesByName(string processName);

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
        public string ProcessName { get; }
    }
}
