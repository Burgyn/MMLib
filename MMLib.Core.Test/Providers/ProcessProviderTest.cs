using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Core.Providers.Fakes;
using MMLib.Core.Providers;
using System.Diagnostics;

namespace MMLib.Core.Test.Providers
{
    [TestClass]
    public class ProcessProviderTest
    {
        [TestMethod]
        public void Default_Test()
        {
            FakeProcessProvider provider = new FakeProcessProvider(null);

            ProcessProvider.Default = provider;
            Assert.AreEqual(provider, ProcessProvider.Default);

            ProcessProvider.Default = null;
        }


        [TestMethod]
        public void BasicProperties_Test()
        {
            ProcessProvider.Default = null;
            Process process = Process.GetCurrentProcess();

            Assert.AreEqual(process.ProcessName, ProcessProvider.Default.ProcessName);
            Assert.AreEqual(process.MainModule.FileName, ProcessProvider.Default.MainModuleFileName);
        }
    }
}
