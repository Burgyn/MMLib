using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            Contract.Requires(target != null);
            Contract.Requires(!string.IsNullOrEmpty(propertyName));

            return (TValue)target.GetPropertyValue(propertyName);
        }

        /// <summary>
        /// Returns the value of the specified property.
        /// </summary>
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
        public static object GetPropertyValue(this object target, string propertyName)
        {
            object ret = null;
            Contract.Requires(target != null);
            Contract.Requires(!string.IsNullOrEmpty(propertyName));

            var targetProperty = target.GetType().GetProperty(propertyName);

            if (targetProperty != null)
            {
                ret = targetProperty.GetValue(target, null);
            }
            else
            {
                throw new ArgumentException("Target object doesn't have property:'{0}'".FormatAsPattern(propertyName));
            }

            return ret;
        }

        /// <summary>
        /// Serialize object value to XElement.
        /// </summary>
        /// <param name="value">Object value for serialization.</param>
        /// <returns>
        /// XElement with serialize data from object.
        /// </returns>
        public static XElement ToXElement(this object value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<XElement>() != null);

            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(value.GetType());
                    xmlSerializer.Serialize(streamWriter, value);
                    return XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
                }
            }
        }

        /// <summary>
        /// Deserialize object from XElement
        /// </summary>
        /// <typeparam name="T">Type of deserialized value.</typeparam>
        /// <param name="value">Serialized value in XElement.</param>
        /// <returns>
        /// Deserialized value.
        /// </returns>
        public static T FromXElement<T>(this XElement value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<T>() != null);

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(value.ToString())))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}
