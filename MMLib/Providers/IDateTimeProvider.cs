using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.Core.Providers
{
    /// <summary>
    /// Interface for DateTimeProvider.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets the current date.
        /// </summary>
        DateTime Today { get; }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on
        /// this computer, expressed as the local time.
        /// </summary>
        DateTime Now { get; }
    }
}
