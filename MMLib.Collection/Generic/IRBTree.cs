using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Collection.Generic
{
    /// <summary>
    /// Represent data structure of key/value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the tree.</typeparam>
    /// <typeparam name="TValue">The type of values in the tree.</typeparam>
    public interface IRBTree<TKey, TValue> : IDictionary<TKey, TValue>
    {
    }
}
