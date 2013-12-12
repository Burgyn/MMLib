using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators.Repositories
{
    /// <summary>
    /// Word repository.
    /// </summary>
    public class WordRepository : IWordRepository
    {

        #region Private fields

        private Lazy<IList<string>> _wordsList;
        private string _wordsRaw;

        #endregion


        #region Constructor

        public WordRepository()
            : this(Properties.Resources.english_words_lowercase)
        {
           
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="words">Words separate by Environment.NewLine.</param>
        public WordRepository(string words)
        {
            Contract.Requires(!string.IsNullOrEmpty(words));
            _wordsRaw = words;

            _wordsList = new Lazy<IList<string>>(() =>
            {
                return _wordsRaw.Split(new string[] { Environment.NewLine },
                   StringSplitOptions.RemoveEmptyEntries).ToList();
            }, true);
        }

        #endregion


        #region Public Interface

        /// <summary>
        /// Word indexer. Get word by index.
        /// </summary>
        /// <param name="index">Index of word</param>
        /// <returns>Word</returns>
        public string this[int index]
        {
            get
            {
                Contract.Requires(index < _wordsList.Value.Count);

                return _wordsList.Value[index];
            }
        }


        /// <summary>
        /// Count of words.
        /// </summary>
        public int Count
        {
            get { return _wordsList.Value.Count; }
        }

        #endregion
    }
}
