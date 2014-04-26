using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using MMLib.MVVM.Services;
using MMLib.MVVM.ViewModel;
using MMLib.MVVM.Test.Services.Fakes;

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
                FakeAppContent fakeAppContent = new Fakes.FakeAppContent();
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, fakeAppContent);
                target.NavigateHome();

                Assert.IsTrue(fakeAppContent.NavigationIn);
                Assert.IsFalse(fakeAppContent.NavigationOut);
                Assert.AreEqual(fakeAppContent, mainAppViewModel.AppContent);
            }
        }

        [TestMethod]
        public void NavigateTo_Test()
        {
            using (var container = new UnityContainer())
            {
                FakeAppContent fakeAppContent = new Fakes.FakeAppContent();
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                var target = new NavigationService(container, mainAppViewModel, fakeAppContent);
                target.NavigateTo(fakeAppContent);

                Assert.IsTrue(fakeAppContent.NavigationIn);
                Assert.IsFalse(fakeAppContent.NavigationOut);
                Assert.AreEqual(fakeAppContent, mainAppViewModel.AppContent);
            }
        }

        [TestMethod]
        public void NavigateToType_Test()
        {
            using (var container = new UnityContainer())
            {
                FakeAppContent fakeAppContent = new Fakes.FakeAppContent();
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
                FakeAppContent fakeAppContent = new Fakes.FakeAppContent() { Value = 10 };
                AppMainViewModel mainAppViewModel = new AppMainViewModel();
                FakeAppContent homeContent = new Fakes.FakeAppContent() { Value = -1 };
                var target = new NavigationService(container, mainAppViewModel, homeContent);

                Assert.IsFalse(target.CanNavigateBack());

                target.NavigateHome();
                Assert.IsTrue(homeContent.NavigationIn);
                Assert.IsFalse(target.CanNavigateBack());

                target.NavigateTo(fakeAppContent); //10
                Assert.IsTrue(fakeAppContent.NavigationIn);
                Assert.IsTrue(homeContent.NavigationOut);
                Assert.IsTrue(target.CanNavigateBack());

                homeContent.NavigationOut = false; homeContent.NavigationIn = false; fakeAppContent.NavigationOut = false;
                target.NavigateBack(); //-1

                Assert.IsTrue(homeContent.NavigationIn);
                Assert.IsTrue(fakeAppContent.NavigationOut);
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
