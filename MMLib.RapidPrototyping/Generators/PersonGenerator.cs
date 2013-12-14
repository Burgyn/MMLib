using MMLib.RapidPrototyping.Generators.Repositories;
using MMLib.RapidPrototyping.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMLib.Extensions;

namespace MMLib.RapidPrototyping.Generators
{
    /// <summary>
    /// Generator, which know generate persons.
    /// </summary>
    public class PersonGenerator : IPersonGenerator
    {

        #region Constants

        private const string EMAIL_SUFIX = "com";

        #endregion


        #region Private fields

        private IWordGenerator _firstNameGenerator;
        private IWordGenerator _lastNameGenerator;
        private IWordGenerator _emailProviderGenerator;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor. Using a time-dependent default seed value. FirstName and SecondName repository are uset from IoCDContainer.
        /// </summary>
        public PersonGenerator()
        {
            ResolveGenerators();
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public PersonGenerator(int seed)
        {
            ResolveGenerators();
            SetSeed(seed);
        }

        #endregion


        #region Public interfaces

        /// <summary>
        /// Generate next person.
        /// </summary>
        /// <returns>Generated person.</returns>
        public IPerson Next()
        {
            Contract.Ensures(Contract.Result<IPerson>() != null);

            Person person = new Person();
            person.FirstName = _firstNameGenerator.Next();
            person.LastName = _lastNameGenerator.Next();
            person.Mail = string.Format("{0}@{1}.{2}", person.LastName.RemoveDiacritics(),
                _emailProviderGenerator.Next(), EMAIL_SUFIX);

            return person;
        }

        /// <summary>
        /// Generate more persons.
        /// </summary>
        /// <param name="count">Count of generating persons.</param>
        /// <returns>Generated persons</returns>
        public IEnumerable<IPerson> Next(int count)
        {
            Contract.Ensures(Contract.Result<IEnumerable<IPerson>>() != null);
            Contract.Ensures(count > 0);
            IEnumerable<IPerson> persons;

            persons = from i in Enumerable.Range(0, count)
                      select Next();

            return persons;

        }

        #endregion


        #region Private helpers

        private void ResolveGenerators()
        {
            _firstNameGenerator = new WordGenerator(RepositoryDependencyFactory.ResolveFirstNameRepository());
            _lastNameGenerator = new WordGenerator(RepositoryDependencyFactory.ResolveLastNameRepository());
            _emailProviderGenerator = RepositoryDependencyFactory.Resolve<IWordGenerator>();
        }


        private void SetSeed(int seed)
        {
            _firstNameGenerator.SetSeed(seed);
            _lastNameGenerator.SetSeed(seed);
            _emailProviderGenerator.SetSeed(seed);
        }

        #endregion
    }
}
