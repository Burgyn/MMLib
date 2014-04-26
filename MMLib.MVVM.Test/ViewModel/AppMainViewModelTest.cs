using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.MVVM.ViewModel;

namespace MMLib.MVVM.Test.ViewModel
{
    [TestClass]
    public class AppMainViewModelTest
    {
        [TestMethod]
        public void AppContent_Test()
        {
            IAppMainViewModel target = new AppMainViewModel();
            var testAppContent = new TestAppContent();

            target.AppContent = testAppContent;
            Assert.AreEqual(testAppContent, target.AppContent);
        }

        class TestAppContent : IAppContent
        {

            public void OnNavigationIn()
            {
                throw new NotImplementedException();
            }

            public void OnNavigationOut()
            {
                throw new NotImplementedException();
            }
        }
    }
}
