using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MMLib.WPF.Services
{
    /// <summary>
    /// Interface represent StartAppServices
    /// </summary>
    [ServiceContract]
    public interface IStartAppService
    {
        /// <summary>
        /// Activate application
        /// </summary>
        [OperationContract]
        void ActivateApplication();
    }
}
