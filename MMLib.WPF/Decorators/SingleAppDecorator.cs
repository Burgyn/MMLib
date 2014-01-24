using MMLib.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MMLib.WPF.Decorators
{
    /// <summary>
    /// Decorator for make single running application.
    /// </summary>
    public class SingleAppDecorator
    {
        #region Private Fields

        private Application _application;
        private AppService _appService = new AppService();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="application">Application, which we can make single running.</param>
        public SingleAppDecorator(Application application)
        {            
            _application = application;
            _application.Startup += OnApplication_Startup;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Active current application.
        /// </summary>
        public void ActiveApplication()
        {
            if (_application.Windows[0].WindowState == WindowState.Minimized)
            {
                _application.Windows[0].WindowState = WindowState.Normal;
            }
            _application.Windows[0].Activate();
        }

        #endregion

        #region Private hendler

        private void OnApplication_Startup(object sender, StartupEventArgs e)
        {
            if (CanStartUp())
            {
                StartAppService.InjectReceiver(this);
                _appService.StartReceiving();
            }
            else
            {
                _appService.ActivateApp();
                _application.Shutdown();
            }
        }

        #endregion

        #region Private helpers

        private bool CanStartUp()
        {
            bool ret = true;

            var actualProcess = MMLib.Core.Providers.ProcessProvider.Default;
            var actualProcessName = actualProcess.ProcessName;
            var exeFullPath = actualProcess.MainModuleFileName;
            var k3kRunningProcesses = actualProcess.GetProcessesByName(actualProcess.ProcessName).ToList();
            if (k3kRunningProcesses.Count > 1 &&
                k3kRunningProcesses.Any(p => p.MainModuleFileName == exeFullPath && p.Id != actualProcess.Id))
            {
                ret = false;
            }

            return ret;
        }

        #endregion
    }
}
