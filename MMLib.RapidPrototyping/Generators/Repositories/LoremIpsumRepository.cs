using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators.Repositories
{
    /// <summary>
    /// Repository for lorem ipsum.
    /// </summary>
    public class LoremIpsumRepository : WordRepository, ILoremIpsumRepository
    {
        #region Constructors

        /// <summary>
        /// Constructor. Use Lorem ipsum sentences from resources.
        /// </summary>
        public LoremIpsumRepository()
            : this(Properties.Resources.loremIpsum)
        {

        } 


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sentences">Sentences separate by Environment.NewLine.</param>
        public LoremIpsumRepository(string sentences) 
            :base(sentences)
        { }

        #endregion
    }
}
