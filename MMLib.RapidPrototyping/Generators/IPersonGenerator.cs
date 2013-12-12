using MMLib.RapidPrototyping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators
{
    /// <summary>
    /// Indetrface for generator, which know generate persons.
    /// </summary>
    public interface IPersonGenerator
    {
        /// <summary>
        /// Generate next person.
        /// </summary>
        /// <returns>Generated person.</returns>
        IPerson Next();


        /// <summary>
        /// Generate more persons.
        /// </summary>
        /// <param name="count">Count of generating persons.</param>
        /// <returns>Generated persons</returns>
        IEnumerable<IPerson> Next(int count);
    }
}
