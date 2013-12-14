using MMLib.RapidPrototyping.Generators.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators
{
    /// <summary>
    /// Class which know generate word.
    /// </summary>
    public class WordGenerator : IWordGenerator
    {

        #region Private fields

        private Random _random;
        private IWordRepository _wordRepository;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor. Use word repository IoCDContainer. And using a time-dependent default seed value.
        /// </summary>
        public WordGenerator()
        {
            _wordRepository = RepositoryDependencyFactory.Resolve<IWordRepository>();
            _random = new Random();
        }


        /// <summary>
        ///  Constructor. Use word repository IoCDContainer.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public WordGenerator(int seed)
        {
            _wordRepository = RepositoryDependencyFactory.Resolve<IWordRepository>();
            _random = new Random(seed);
        }


        /// <summary>
        /// Constructor. Using a time-dependent default seed value.
        /// </summary>
        /// <param name="wordRepository">Word repository.</param>
        public WordGenerator(IWordRepository wordRepository)
        {
            Contract.Requires(wordRepository != null);

            _random = new Random();
            _wordRepository = wordRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        /// <param name="wordRepository">Word repository.</param>
        public WordGenerator(int seed, IWordRepository wordRepository)
        {
            Contract.Requires(wordRepository != null);

            _wordRepository = wordRepository;
            _random = new Random(seed);
        }

        #endregion


        #region Public Interfaces

        /// <summary>
        /// Generate next word.
        /// </summary>
        /// <returns>Next genereted word.</returns>
        public string Next()
        {
            Contract.Ensures(Contract.Result<string>() != null);
            int wordIndex = _random.Next(0, _wordRepository.Count - 1);

            return _wordRepository[wordIndex];
        }


        /// <summary>
        /// Generate words.
        /// </summary>
        /// <param name="count">Count of new generated words. Rather then 0.</param>
        /// <returns>Generated words.</returns>
        public IEnumerable<string> Next(int count)
        {
            Contract.Requires(count > 0);
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            return from i in Enumerable.Range(0, count)
                   select Next();
        }


        /// <summary>
        /// Set new seed.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public void SetSeed(int seed)
        {
            _random = new Random(seed);
        }

        #endregion
       
    }
}
