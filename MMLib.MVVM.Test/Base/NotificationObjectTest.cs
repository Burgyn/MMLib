﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Test.Base
{
    [TestClass]
    public class NotificationObjectTest
    {
        [TestMethod]
        public void OnPropertyChange_StringParamTest()
        {
            FakeNotificationObject target = new FakeNotificationObject();
            string propertyName = string.Empty;
            target.PropertyChanged += (a, b) =>
            {
                propertyName = b.PropertyName;
            };

            target.PropertyName = "Test";
            Assert.AreEqual("PropertyName", propertyName);
            Assert.AreEqual("Test", target.PropertyName);
        }

        [TestMethod]
        public void OnPropertyChange_LambdaParamTest()
        {
            FakeNotificationObject target = new FakeNotificationObject();
            string propertyName = string.Empty;
            target.PropertyChanged += (a, b) =>
            {
                propertyName = b.PropertyName;
            };

            target.PropertyLambda = 10;
            Assert.AreEqual("PropertyLambda", propertyName);
            Assert.AreEqual(10, target.PropertyLambda);
        }

        [TestMethod]
        public void OnPropertyChange_SetPropertyValueTest()
        {
            FakeNotificationObject target = new FakeNotificationObject();
            string propertyName = string.Empty;
            target.PropertyChanged += (a, b) =>
            {
                propertyName = b.PropertyName;
            };

            target.PropertySetP = "Test";
            Assert.AreEqual("PropertySetP", propertyName);
            Assert.AreEqual("Test", target.PropertySetP);

            propertyName = string.Empty;
            target.PropertySetP = "Test";

            Assert.AreEqual(string.Empty, propertyName);
            Assert.AreEqual("Test", target.PropertySetP);

            target.PropertySetP = null;
            Assert.AreEqual("PropertySetP", propertyName);
            Assert.IsNull(target.PropertySetP);
        }
    }
}
