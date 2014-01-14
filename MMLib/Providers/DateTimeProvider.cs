using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Core.Providers
{
    /// <summary>
    /// Provider for islated application from DateTime
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {

        #region Private Fields

        private static IDateTimeProvider _instance;

        #endregion


        #region Constructors

        protected DateTimeProvider()
        {

        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the current date.
        /// </summary>
        public virtual DateTime Today
        {
            get { return DateTime.Today; }
        }


        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on
        /// this computer, expressed as the local time.
        /// </summary>
        public virtual DateTime Now
        {
            get { return DateTime.Now; }
        }


        /// <summary>
        /// Default provider.
        /// </summary>
        public static IDateTimeProvider Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DateTimeProvider();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        #endregion
    }
}
