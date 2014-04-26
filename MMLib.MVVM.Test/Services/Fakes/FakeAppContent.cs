using MMLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.Services.Fakes
{
    /// <summary>
    /// Fake app content for testing.
    /// </summary>
    public class FakeAppContent : IAppContent
    {
        public FakeAppContent()
        {
            NavigationOut = false;
            NavigationIn = false;
        }

        public int Value { get; set; }

        public bool NavigationIn { get; set; }

        public bool NavigationOut { get; set; }

        public void OnNavigationIn()
        {
            NavigationIn = true;
        }

        public void OnNavigationOut()
        {
            NavigationOut = true;
        }
    }
}
