using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.RapidPrototyping.Generators.Repositories;
using MMLib.RapidPrototyping.Generators;
using System.Linq;

namespace MMLib.RapidPrototyping.Test.Generators
{
    [TestClass]
    public class PersonGeneratorTest
    {
        [TestMethod]
        public void Next_Test()
        {
            IPersonGenerator target = new PersonGenerator(1);

            var person = target.Next();
            Assert.AreEqual("Zuzka", person.FirstName);
            Assert.AreEqual("Hobza", person.LastName);
            Assert.AreEqual("Hobza@cau.com", person.Mail);

            person = target.Next();
            Assert.AreEqual("Milan", person.FirstName);
            Assert.AreEqual("Hobza", person.LastName);
            Assert.AreEqual("Hobza@ahoj.com", person.Mail);
        }


        [TestMethod]
        public void NextMore_Test()
        {
            IPersonGenerator target = new PersonGenerator(1);

            var persons = target.Next(5).ToList();

            Assert.AreEqual(5, persons.Count);
            Assert.AreEqual("Zuzka", persons[0].FirstName);
            Assert.AreEqual("Hobza", persons[0].LastName);
            Assert.AreEqual("Hobza@cau.com", persons[0].Mail);

            Assert.AreEqual("Juraj", persons[4].FirstName);
            Assert.AreEqual("Petrák", persons[4].LastName);
            Assert.AreEqual("Petrak@radar.com", persons[4].Mail);
        }
    }
}
