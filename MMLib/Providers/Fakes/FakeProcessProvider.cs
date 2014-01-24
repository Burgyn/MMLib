using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.Core.Providers.Fakes
{
    /// <summary>
    /// Fake process provider for testing.
    /// </summary>
    public class FakeProcessProvider : IProcessProvider
    {
        public IProcessProvider GetCurrentProcess()
        {
            throw new NotImplementedException();
        }

        public string MainModuleFileName
        {
            get { throw new NotImplementedException(); }
        }

        public IProcessProvider[] GetProcessesByName(string processName)
        {
            throw new NotImplementedException();
        }

        public string ProcessName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
