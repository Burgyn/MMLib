using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MMLib.Extensions
{
    /// <summary>
    /// Extensions for DataTime class.
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Determine whether date is weekend.
        /// </summary>
        /// <param name="value">Date, which want tested.</param>
        /// <returns>true if date is in weekend, otherwise false.</returns>
        public static bool IsWeekend(this DateTime value)
        {
            Contract.Requires(value != null);

            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }


        /// <summary>
        /// Determine whether year from date is leap.
        /// </summary>
        /// <param name="value">Date, which want tested.</param>
        /// <returns>true if year is leap, otherwise false.</returns>
        public static bool IsLeapYear(this DateTime value)
        {
            Contract.Requires(value != null);

            return value.Year % 4 == 0;
        }


        /// <summary>
        /// Determine whether day from date is last day of the month.
        /// </summary>
        /// <param name="value">Date, which want tested.</param>
        /// <returns>true if leap, otherwise false.</returns>
        public static bool IsLastDayOfMonth(this DateTime value)
        {
            Contract.Requires(value != null);

            return value == new DateTime(value.Year, value.Month, 1).AddMonths(1).AddDays(-1);
        }

        //ToDo: 
        //Age
        //IsInRange
    }
}
