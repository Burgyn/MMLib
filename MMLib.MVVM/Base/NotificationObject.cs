using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MMLib.MVVM.Base
{
    /// <summary>
    /// Class which know notifies clients that a property value has changed.
    /// </summary>
    public abstract class NotificationObject : INotifyPropertyChanged
    {

        #region Private Constants

        private const string PROPERT_SET_PREFIX = "set_";

        #endregion


        #region INotifyPropertyChanged Members

        /// <summary>        
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>        
        /// Raise PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of property which was changed.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /// <summary>        
        /// Raise PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of property which was changed.</param>
        protected void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            MemberExpression memberExpression = (MemberExpression)exp.Body;
            string propertyName = memberExpression.Member.Name;

            OnPropertyChanged(propertyName);
        }

        #endregion INotifyPropertyChanged Members


        #region Debugging Aides

        /// <summary>        
        /// Check if property name exist in this object.
        /// </summary>
        [Conditional("DEBUG"), DebuggerStepThrough()]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name XYZ: " + propertyName;
                throw new Exception(msg);
            }
        }

        #endregion


        #region Private fields

        private string CheckAndCorrectPropertyName(string propertyName)
        {
            if (propertyName.StartsWith(PROPERT_SET_PREFIX))
            {
                propertyName = propertyName.Replace(PROPERT_SET_PREFIX, "");
            }
            return propertyName;
        }

        #endregion
    }
}
