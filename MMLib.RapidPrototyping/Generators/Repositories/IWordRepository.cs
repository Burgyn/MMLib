using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators.Repositories
{
    /// <summary>
    /// Interface for word repository.
    /// </summary>
    public interface IWordRepository
    {
        /// <summary>
        /// Word indexer. Get word by index.
        /// </summary>
        /// <param name="index">Index of word</param>
        /// <returns>Word</returns>
        string this[int index] { get; }


        /// <summary>
        /// Count of words.
        /// </summary>
        int Count { get; }
    }
}
