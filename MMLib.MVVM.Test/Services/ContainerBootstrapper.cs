using Microsoft.Practices.Unity;
using MMLib.MVVM.Services;
using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.Services
{
    /// <summary>
    /// Bootstraper for unity container.
    /// </summary>
    public static class ContainerBootstrapper
    {
        /// <summary>
        /// Register types for MMLib.MVVM
        /// </summary>
        /// <param name="container">Unity container.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INavigationService, NavigationService>(
                new InjectionConstructor(container, typeof(AppMainViewModel), typeof(Fakes.FakeAppContent)));
        }
    }
}
