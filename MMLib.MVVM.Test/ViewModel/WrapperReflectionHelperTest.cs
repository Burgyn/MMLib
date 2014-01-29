using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.MVVM.Test.Model.TestClasses;
using MMLib.MVVM.Test.ViewModel.TestClasses;
using MMLib.MVVM.ViewModel;

namespace MMLib.MVVM.Test.ViewModel
{
    [TestClass]
    public class WrapperReflectionHelperTest
    {

        [TestMethod]
        public void WrappeModelToViewModel_Test()
        {
            DateTime now = DateTime.Now;
            TestModel model = new TestModel()
            {
                StringValue = "Hello",
                NonWrapped = "By",
                Id = 1,
                DoubleValue = 12,
                DateTimeValue = now
            };
            TestModelViewModel viewModel = new TestModelViewModel();

            var target = new WrapperReflectionHelper<TestModel>(model, viewModel);
            Assert.IsNull(viewModel.Model);

            target.WrappeModelToViewModel();

            Assert.AreEqual(model, viewModel.Model);
            Assert.AreEqual(model.DateTimeValue, viewModel.DateTimeValue);
            Assert.AreEqual(model.DoubleValue, viewModel.DoubleValue);
            Assert.AreEqual(model.StringValue, viewModel.StringValue);
            Assert.AreNotEqual(model.NonWrapped, viewModel.NonWrapped);
        }

        [TestMethod]
        public void SaveChanges_Test()
        {
            DateTime now = DateTime.Now;
            TestModel model = new TestModel();
            TestModelViewModel viewModel = new TestModelViewModel();

            var target = new WrapperReflectionHelper<TestModel>(model, viewModel);

            viewModel.DoubleValue = 12;
            viewModel.StringValue = "Mino";
            viewModel.NonWrapped = "Test";
            viewModel.DateTimeValue = now;

            target.SaveChangesToModel();

            Assert.AreEqual(model.DoubleValue, 12);
            Assert.AreEqual(model.StringValue, "Mino");
            Assert.AreEqual(model.DateTimeValue, now);

            Assert.AreNotEqual(model.NonWrapped, "Test");
        }
    }
}
