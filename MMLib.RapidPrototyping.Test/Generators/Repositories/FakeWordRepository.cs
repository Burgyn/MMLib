using MMLib.RapidPrototyping.Generators.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Test.Generators.Repositories
{
    /// <summary>
    /// Fake word repository for testing
    /// </summary>
    public class FakeWordRepository : WordRepository
    {
        public FakeWordRepository()
            :base(Properties.Resources.slovak_words_lowercase)
        {           
        }        
    }
}
