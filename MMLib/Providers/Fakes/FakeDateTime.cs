using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Core.Providers.Fakes
{
    /// <summary>
    /// Fake DateTimeProvider for defined Now and Today.
    /// </summary>
    public class FakeDateTime : DateTimeProvider
    {

        #region Private fields

        private DateTime _now; 

        #endregion


        #region MyRegion

        public FakeDateTime(DateTime now)
        {
            _now = now;
        } 

        #endregion


        #region Overrides

        /// <summary>
        /// Gets Date and time, which I defined in constructor
        /// </summary>
        public override DateTime Now
        {
            get
            {
                return _now;
            }
        }


        /// <summary>
        /// Gets the date, which I defined in constructor.
        /// </summary>
        public override DateTime Today
        {
            get
            {
                return _now.Date;
            }
        } 

        #endregion
    }
}
