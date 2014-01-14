﻿using MMLib.Core.Providers;
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


        /// <summary>
        /// Determine whether date is in date range.
        /// </summary>
        /// <param name="value">Checked date.</param>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns>
        /// true if value is in date range, otherwise false.
        /// </returns>
        public static bool IsInRange(this DateTime value, DateTime startDate, DateTime endDate)
        {
            Contract.Requires(value != null);
            Contract.Requires(startDate != null);
            Contract.Requires(endDate != null);
            Contract.Requires(endDate > startDate);

            return value >= startDate && value <= endDate;
        }


        /// <summary>
        /// Get Age by birthDay date.
        /// </summary>
        /// <param name="birthDay">Date of birthDay.</param>
        /// <returns>
        /// Count of Age from birthDay to Today.
        /// </returns>
        public static int Age(this DateTime birthDay)
        {
            Contract.Requires(birthDay != null);
            Contract.Requires(birthDay.Date <= DateTimeProvider.Default.Today);
            DateTime today = DateTimeProvider.Default.Today;
            int ret = 0;

            if (birthDay.Date != DateTimeProvider.Default.Today)
            {
                if ((today.Month < birthDay.Month || today.Month == birthDay.Month) &&
                    today.Day < birthDay.Day)
                {
                    ret = today.Year - birthDay.Year - 1;
                }
                else
                {
                    ret = today.Year - birthDay.Year;
                }
            }

            return ret;
        }


        /// <summary>
        /// Determine whether value date is today.
        /// </summary>
        /// <param name="value">Checked date.</param>
        /// <returns>
        /// true if value is Today, otherwise false.
        /// </returns>
        public static bool IsToday(this DateTime value)
        {
            Contract.Requires(value != null);

            return value.Date == DateTimeProvider.Default.Today;
        }

        //ToDo: 
        //GetCountDaysOfMonth
        //GetFirstDayOfMonth
        //GetLastDayOfMonth
        //GetFirstDayOfWeek
        //GetLastDayOfWeek
        //GetWeeksWeekday
        //GetNextWeekday
        //GetPreviousWeekday
        //AddWeeks
    }
}
