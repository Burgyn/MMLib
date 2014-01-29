using MMLib.MVVM.Test.Model.TestClasses;
using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.ViewModel.TestClasses
{
    public class TestModelViewModel : IModelWrapperViewModel<TestModel>, ITestModel
    {
        public string StringValue { get; set; }

        public double DoubleValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        public string NonWrapped { get; set; }

        public TestModel Model{get;set;}
    }
}
