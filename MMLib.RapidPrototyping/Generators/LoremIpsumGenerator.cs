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
    /// Lorem ipsum generator.
    /// </summary>
    public class LoremIpsumGenerator : ILoremIpsumGenerator
    {

        #region Constants

        private const int DEFAULT_MAX_SENTENCES_COUNT = 9; 

        #endregion

        #region Private fields

        private Random _random;
        private ILoremIpsumRepository _loremIpsumRepository;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor. Use lorem ipsum repository from IoCDContainer. And using a time-dependent default seed value.
        /// </summary>
        public LoremIpsumGenerator()
        {
            _random = new Random();
            _loremIpsumRepository = RepositoryDependencyFactory.Resolve<ILoremIpsumRepository>();
        }


        /// <summary>
        ///  Constructor. Use lorem ipsum repository IoCDContainer.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public LoremIpsumGenerator(int seed)
        {
            _random = new Random(seed);
            _loremIpsumRepository = RepositoryDependencyFactory.Resolve<ILoremIpsumRepository>();
        }


        /// <summary>
        /// Constructor. Using a time-dependent default seed value.
        /// </summary>
        /// <param name="loremIpsumRepository">Lorem ipsum repository.</param>
        public LoremIpsumGenerator(ILoremIpsumRepository loremIpsumRepository)
        {
            Contract.Requires(loremIpsumRepository != null);

            _random = new Random();
            _loremIpsumRepository = loremIpsumRepository;
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        /// <param name="loremIpsumRepository">Lorem ipsum repository.</param>
        public LoremIpsumGenerator(int seed, ILoremIpsumRepository loremIpsumRepository)
        {
            Contract.Requires(loremIpsumRepository != null);

            _random = new Random(seed);
            _loremIpsumRepository = loremIpsumRepository;
        }

        #endregion


        #region Public methods.

        /// <summary>
        /// Generate next lorem ipsum paragraphs.
        /// </summary>
        /// <param name="paragraphsCount">Paragraphs count. Rather then 0.</param>
        /// <returns>
        /// Lorem ipsum paragraphs separate by Enviroment.NewLine.
        /// </returns>
        public string Next(int paragraphsCount)
        {
            Contract.Requires(paragraphsCount > 0);
            Contract.Ensures(string.IsNullOrEmpty(Contract.Result<string>()));

            return Next(paragraphsCount, _random.Next(DEFAULT_MAX_SENTENCES_COUNT + 1));
        }


        /// <summary>
        /// Generate next lorem ipsum paragraphs.
        /// </summary>
        /// <param name="paragraphsCount">Paragraphs count. Rather then 0.</param>
        /// <param name="maxSentencesInParagraph">Max count of sentences in paragraphs. Rather then 0.</param>
        /// <returns>
        /// Lorem ipsum paragraphs separate by Enviroment.NewLine.
        /// </returns>
        public string Next(int paragraphsCount, int maxSentencesInParagraph)
        {
            Contract.Requires(paragraphsCount > 0);
            Contract.Requires(maxSentencesInParagraph > 0);
            Contract.Ensures(string.IsNullOrEmpty(Contract.Result<string>()));

            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < paragraphsCount; i++)
            {
                var sentencesCount = _random.Next(maxSentencesInParagraph - 1) + 1;
                var sentences = String.Join(" ", (from p in Enumerable.Range(0, sentencesCount)
                                                  select _loremIpsumRepository[_random.Next(_loremIpsumRepository.Count - 1)]));

                ret.AppendLine(sentences);
            }


            return ret.ToString();
        }

        #endregion
    }
}
