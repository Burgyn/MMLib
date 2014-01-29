using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Model
{
    /// <summary>
    /// Attribute for model class properties. If proeprty has this attribute, this property will not be wrapped to viewModel. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NonWrappedAttribute : Attribute
    {
    }
}
