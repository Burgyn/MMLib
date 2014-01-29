using MMLib.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.Model.TestClasses
{
    /// <summary>
    /// Test model class for testing.
    /// </summary>
    public class TestModel : IModel, ITestModel
    {
        public int Id { get; set; }

        public string StringValue { get; set; }

        public double DoubleValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        [NonWrapped]
        public string NonWrapped { get; set; }
    }
}
