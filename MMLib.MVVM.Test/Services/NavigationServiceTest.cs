using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using MMLib.MVVM.Services;
using MMLib.MVVM.ViewModel;

namespace MMLib.MVVM.Test.Services
{
    [TestClass]
    public class NavigationServiceTest
    {
        [TestMethod]
        public void NavigateToHome_Test()
        {
            using (var container = new UnityContainer())
            {
                IAppContent fakeAppContent = new Fakes.FakeAppContent();
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, fakeAppContent);
                target.NavigateHome();

                Assert.AreEqual(fakeAppContent, mainAppViewModel.AppContent);
            }
        }

        [TestMethod]
        public void NavigateTo_Test()
        {
            using (var container = new UnityContainer())
            {
                IAppContent fakeAppContent = new Fakes.FakeAppContent();
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, fakeAppContent);
                target.NavigateTo(fakeAppContent);

                Assert.AreEqual(fakeAppContent, mainAppViewModel.AppContent);
            }
        }

        [TestMethod]
        public void NavigateToType_Test()
        {
            using (var container = new UnityContainer())
            {
                IAppContent fakeAppContent = new Fakes.FakeAppContent();
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, fakeAppContent);

                target.NavigateTo(typeof(Fakes.FakeAppContent));

                Assert.IsInstanceOfType(mainAppViewModel.AppContent, typeof(Fakes.FakeAppContent));
            }
        }

        [TestMethod]
        public void NavigateToBack_Test()
        {
            using (var container = new UnityContainer())
            {
                IAppContent fakeAppContent = new Fakes.FakeAppContent() { Value = 10 };
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, new Fakes.FakeAppContent() { Value = -1 });

                Assert.IsFalse(target.CanNavigateBack());

                target.NavigateHome();
                Assert.IsFalse(target.CanNavigateBack());

                target.NavigateTo(fakeAppContent); //10
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateBack(); //-1
                Assert.IsFalse(target.CanNavigateBack());
                Assert.AreEqual(-1, (mainAppViewModel.AppContent as Fakes.FakeAppContent).Value);

                target.NavigateTo(fakeAppContent); //10
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateTo(typeof(Fakes.FakeAppContent)); //0
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateTo(new Fakes.FakeAppContent() { Value = 15 }); //15
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateBack(); //0
                Assert.AreEqual(0, (mainAppViewModel.AppContent as Fakes.FakeAppContent).Value);
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateBack(); //10
                Assert.AreEqual(10, (mainAppViewModel.AppContent as Fakes.FakeAppContent).Value);
                Assert.IsTrue(target.CanNavigateBack());

                target.NavigateBack(); //-1
                Assert.AreEqual(-1, (mainAppViewModel.AppContent as Fakes.FakeAppContent).Value);
                Assert.IsFalse(target.CanNavigateBack());
            }
        }
    }
}
