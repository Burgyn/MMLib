using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.Model.TestClasses
{
    /// <summary>
    /// Interface for testing model.
    /// </summary>
    public interface ITestModel
    {
        string StringValue { get; set; }

        double DoubleValue { get; set; }

        DateTime DateTimeValue { get; set; }

        string NonWrapped { get; set; }
    }
}
