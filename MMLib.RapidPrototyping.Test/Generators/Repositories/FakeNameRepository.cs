using MMLib.RapidPrototyping.Generators;
using MMLib.RapidPrototyping.Generators.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Test.Generators.Repositories
{
    /// <summary>
    /// Fake class for generate names.
    /// </summary>
    public class FakeNameRepository : IWordRepository
    {
        private WordRepository _wordRepository;

        public FakeNameRepository(bool firstName)
        {
            if (firstName)
            {
                _wordRepository = new WordRepository(Properties.Resources.slovak_first_name);
            }
            else
            {
                _wordRepository = new WordRepository(Properties.Resources.slovak_last_name);
            }
        }


        public string this[int index]
        {
            get { return _wordRepository[index]; }
        }

        public int Count
        {
            get { return _wordRepository.Count; }
        }
    }
}
