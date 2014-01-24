using MMLib.WPF.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.WPF.Services
{
    /// <summary>
    /// Services for starting application.
    /// </summary>
    public class StartAppService : IStartAppService
    {
        #region Private Fields

        private static SingleAppDecorator _singleAppDecorator;

        #endregion

        #region Public methods

        /// <summary>
        /// Activate application
        /// </summary>
        public void ActivateApplication()
        {
            _singleAppDecorator.ActiveApplication();
        }


        /// <summary>
        /// Inject single app decorator.
        /// </summary>
        /// <param name="singleAppDecorator">Single app decorator.</param>
        public static void InjectReceiver(SingleAppDecorator singleAppDecorator)
        {
            _singleAppDecorator = singleAppDecorator;
        }

        #endregion       
    }
}
