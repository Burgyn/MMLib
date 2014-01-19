using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.MVVM.Command;

namespace MMLib.MVVM.Test.Command
{
    [TestClass]
    public class RelayCommandTest
    {
        [TestMethod]
        public void Execute_DefaultTest()
        {
            bool wasCalled = false;
            RelayCommand target = new RelayCommand((p) => {
                wasCalled = true;
            });
            Assert.IsFalse(wasCalled);
            target.Execute();

            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void Execute_ParamTest()
        {
            string value = string.Empty;
            RelayCommand target = new RelayCommand((p) =>
            {
                value = p.ToString();
            });

            Assert.AreEqual(string.Empty, value);
            target.Execute("Test");

            Assert.AreEqual("Test", value);
        }

        [TestMethod]
        public void CanExecute_DefaultTest()
        {
            RelayCommand target = new RelayCommand((p) =>
            {
            });
            
            Assert.IsTrue(target.CanExecute(null));
        }

        [TestMethod]
        public void CanExecute_MethodTest()
        {
            bool canExecute = true;
            RelayCommand target = new RelayCommand((p) =>
            {
            }, (p) => { return canExecute; });

            Assert.IsTrue(target.CanExecute(null));

            canExecute = false;
            Assert.IsFalse(target.CanExecute(null));

            canExecute = true;
            Assert.IsTrue(target.CanExecute(null));
        }

        [TestMethod]
        public void CanExecute_ParamTest()
        {
            RelayCommand target = new RelayCommand((p) =>
            {
            }, (p) => { return (bool)p; });

            Assert.IsTrue(target.CanExecute(true));

            Assert.IsFalse(target.CanExecute(false));

            Assert.IsTrue(target.CanExecute(true));
        }


        [TestMethod]
        public void Execute_CannotExecutTest()
        {
            var value = "test";
            bool canExecute = true;
            RelayCommand target = new RelayCommand((p) =>
            {
                value = p.ToString();
            }, (p) => { return canExecute; });

            target.Execute("mino");
            Assert.AreEqual("mino", value);

            value = string.Empty;
            canExecute = false;

            target.Execute("mino");
            Assert.AreEqual(string.Empty, value);
        }
    }
}
