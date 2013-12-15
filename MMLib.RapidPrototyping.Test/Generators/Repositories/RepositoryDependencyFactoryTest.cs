using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMLib.RapidPrototyping.Generators.Repositories;

namespace MMLib.RapidPrototyping.Test.Generators.Repositories
{
    [TestClass]
    public class RepositoryDependencyFactoryTest
    {
        [TestMethod]
        public void RegisterFirstNameRepository_Test()
        {
            FakeNameRepository expected = new FakeNameRepository(true);
            RepositoryDependencyFactory.RegisterFirstNameRepository(expected);

            Assert.AreEqual(expected, RepositoryDependencyFactory.ResolveFirstNameRepository());
        }


        [TestMethod]
        public void RegisterFLastNameRepository_Test()
        {
            FakeNameRepository expected = new FakeNameRepository(false);
            RepositoryDependencyFactory.RegisterLastNameRepository(expected);

            Assert.AreEqual(expected, RepositoryDependencyFactory.ResolveLastNameRepository());
        }
    }
}
