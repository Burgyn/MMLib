using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MMLib.WPF.Services
{
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
                    "net.pipe://localhost/PipeAppService"));

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
            _host = new ServiceHost(
                   typeof(StartAppService),
                   new Uri[]{
                        new Uri("net.pipe://localhost")});

            _host.AddServiceEndpoint(typeof(IStartAppService),
                new NetNamedPipeBinding(), "PipeAppService");

            _host.Open();
        }

        #endregion

        #region IDisposable

        private bool disposed = false;
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

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }
}
