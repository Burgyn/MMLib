using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.Core.Providers.Fakes;
using MMLib.Core.Providers;
using System.Collections.Generic;
using System.Linq;

namespace MMLib.Core.Test.Providers.Fakes
{
    [TestClass]
    public class FakeProcessProviderTest
    {
        [TestMethod]
        public void BasicProperty_Test()
        {
            FakeProcessProvider target = new FakeProcessProvider(new List<KeyValuePair<string, string>>());
            target.MainModuleFileName = "Test";
            target.ProcessName = "TestProcess";

            Assert.AreEqual("Test", target.GetCurrentProcess().MainModuleFileName);
            Assert.AreEqual("TestProcess", target.GetCurrentProcess().ProcessName);
        }


        [TestMethod]
        public void GetProcessesByName_Test()
        {
            var processes = new List<KeyValuePair<string, string>>();
            processes.Add(new KeyValuePair<string, string>("Test", "MainTest"));
            processes.Add(new KeyValuePair<string, string>("Test", "MainTest2"));
            processes.Add(new KeyValuePair<string, string>("Proc", "MainProc"));
            FakeProcessProvider target = new FakeProcessProvider(processes);

            Assert.AreEqual("MainTest", target.GetProcessesByName("Test")[0].MainModuleFileName);
            Assert.AreEqual("MainTest2", target.GetProcessesByName("Test")[1].MainModuleFileName);
            Assert.AreEqual("MainProc", target.GetProcessesByName("Proc")[0].MainModuleFileName);

            Assert.AreEqual(0, target.GetProcessesByName("FSDs").Count());
        }
    }
}
