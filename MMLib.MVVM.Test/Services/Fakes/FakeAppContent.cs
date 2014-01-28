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
        public int Value { get; set; }
    }
}
