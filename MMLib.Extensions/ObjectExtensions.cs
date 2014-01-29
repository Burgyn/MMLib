using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MMLib.Extensions
{
    /// <summary>
    /// Extensions for object.
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Sets the value of the specified property.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <param name="propertyName">A value which specifies the property's name.</param>
        /// <param name="newValue">An object which represents the new value</param>
        /// <returns>true if target object has this property, otherwise false.</returns>
        /// <exception cref="ArgumentException">
        /// Occured when newValue doesn't have same type as property.
        /// </exception>
        public static bool SetPropertyValue(this object target, string propertyName, object newValue)
        {
            Contract.Requires(target != null);
            Contract.Requires(!string.IsNullOrEmpty(propertyName));

            bool ret = false;
            var targetProperty = target.GetType().GetProperty(propertyName);

            if (targetProperty != null)
            {
                targetProperty.SetValue(target, newValue, null);
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// Returns the value of the specified property.
        /// </summary>
        /// <typeparam name="TValue">Type of return value, which expect.</typeparam>
        /// <param name="target">Target object.</param>
        /// <param name="propertyName">A value which specifies the property's name.</param>
        /// <returns>
        /// Value which represents the value of the specified property. 
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This exception occured, when target object doesn't have specific propertyName.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// This exception occured, when return type is not type of the TValue.
        /// </exception>
        public static TValue GetPropertyValue<TValue>(this object target, string propertyName)
        {
            TValue ret = default(TValue);
            Contract.Requires(target != null);
            Contract.Requires(!string.IsNullOrEmpty(propertyName));

            var targetProperty = target.GetType().GetProperty(propertyName);

            if (targetProperty != null)
            {
                ret = (TValue)targetProperty.GetValue(target, null);
            }
            else
            {
                throw new ArgumentException("Target object doesn't have property:'{0}'".FormatAsPattern(propertyName));
            }

            return ret;
        }
    }
}
