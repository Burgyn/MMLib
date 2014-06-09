using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MMLib.WPF.Services
{
    /// <summary>
    /// App service for single application.
    /// </summary>
    public class AppService : IDisposable
    {
        #region Private Fields

        private IStartAppService _startAppService;
        private ServiceHost _host;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppService()
        {
            ChannelFactory<IStartAppService> pipeFactory =
                new ChannelFactory<IStartAppService>(
                  new NetNamedPipeBinding(),
                  new EndpointAddress(
                    string.Format("net.pipe://localhost/{0}", GetAppName())));

            _startAppService = pipeFactory.CreateChannel();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Active application.
        /// </summary>
        public void ActivateApp()
        {
            _startAppService.ActivateApplication();
        }

        /// <summary>
        /// Start receiving messages.
        /// </summary>
        public void StartReceiving()
        {
            try
            {
                _host = new ServiceHost(
                           typeof(StartAppService),
                           new Uri[]{
                        new Uri("net.pipe://localhost")});

                _host.AddServiceEndpoint(typeof(IStartAppService),
                    new NetNamedPipeBinding(), GetAppName());

                _host.Open();
            }
            catch
            {                
            }
        }

        #endregion

        #region IDisposable

        private bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Is disposing from code?</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_host != null)
                    {
                        _host.Close();
                    }
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region Private helpers

        private string GetAppName()
        {
            return System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        }

        #endregion

    }
}
