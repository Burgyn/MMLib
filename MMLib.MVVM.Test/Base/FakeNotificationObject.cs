using MMLib.MVVM.Base;
using MMLib.MVVM.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MMLib.MVVM.Test.Base
{
    /// <summary>
    /// Fake derivered class of NotificationObjec for testing.
    /// </summary>
    public class FakeNotificationObject : NotificationObject
    {
        private string _propertyName = string.Empty;
        private int _propertyLambda = 0;
        private string _propertySetP = string.Empty;

        /// <summary>
        /// Property which call OnPropertyChange with string parameter.
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set
            {
                if (_propertyName != value)
                {
                    _propertyName = value;
                    OnPropertyChanged("PropertyName");
                }
            }
        }

        /// <summary>
        /// Property which call property change with LambdaExpression.
        /// </summary>
        public int PropertyLambda
        {
            get
            {
                return _propertyLambda;
            }
            set
            {
                if (_propertyLambda != value)
                {
                    _propertyLambda = value;
                    OnPropertyChanged(() => PropertyLambda);
                }
            }
        }

        /// <summary>
        /// Property which use SetPropertyValue method.
        /// </summary>
        public string PropertySetP
        {
            get { return _propertySetP; }
            set
            {
                SetPropertyValue<string>(() => PropertySetP, ref _propertySetP, value);
            }
        }        
    }
}
