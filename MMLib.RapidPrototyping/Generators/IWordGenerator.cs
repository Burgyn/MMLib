using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators
{
    /// <summary>
    /// Interface for class, which generate word.
    /// </summary>
    public interface IWordGenerator
    {
        /// <summary>
        /// Generate next word.
        /// </summary>
        /// <returns>Next genereted word.</returns>
        string Next();

        /// <summary>
        /// Set new seed.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random sequence. If a negative number is specified, the absolute value of the number is used.</param>
        void SetSeed(int seed);
    }
}
