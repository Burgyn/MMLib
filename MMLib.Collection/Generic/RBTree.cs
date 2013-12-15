using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Collection.Generic
{
    /// <summary>
    /// Represent data structure of key/value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the tree.</typeparam>
    /// <typeparam name="TValue">The type of values in the tree.</typeparam>
    [Serializable]
    [ComVisible(false)]
    [DebuggerDisplay("Count = {Count}")]
    public class RBTree<TKey, TValue> : IRBTree<TKey, TValue>
    {

        #region Public Interfaces

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>
        /// The value associated with the specified key. If the specified key is not
        /// found, a get operation throws a System.Collections.Generic.KeyNotFoundException,
        /// and a set operation creates a new element with the specified key.
        /// </returns>
        public TValue this[TKey key]
        {
            get
            {
                Contract.Requires(key != null);
                throw new NotImplementedException();
            }
            set
            {
                Contract.Requires(key != null);
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///  Gets a collection containing the keys.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a collection containing the values.
        /// </summary>
        public ICollection<TValue> Values
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <exception cref="System.ArgumentException">
        /// An element with the same key already exists.
        /// </exception>
        public void Add(TKey key, TValue value)
        {
            Contract.Requires(key != null);
            Contract.Requires(value != null);

            throw new NotImplementedException();
        }


        /// <summary>
        ///  Gets the number of elements contained in the tree.
        /// </summary>
        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value indicating whether the tree is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="item">Key and value pair to add.</param>
        /// <exception cref="System.ArgumentException">
        /// An element with the same key already exists.
        /// </exception>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the System.Collections.Generic.Dictionary<TKey,TValue>
        /// contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the three.</param>
        /// <returns>
        /// true if the tree contains an element with the specified key; otherwise, false.
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            Contract.Requires(key != null);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the value with the specified key from the tree.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// true if the element is successfully found and removed; otherwise, false.
        /// This method returns false if key is not found.
        /// </returns>
        public bool Remove(TKey key)
        {
            Contract.Requires(key != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified
        /// key, if the key is found; otherwise, the default value for the type of the
        /// value parameter. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// true if the tree contains an element with the specified key; otherwise, false.
        /// </returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            Contract.Requires(key != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all keys and values from the tree.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the System.Collections.Generic.Dictionary<TKey,TValue>
        /// contains the specified key.
        /// </summary>
        /// <param name="item">Key value pair.</param>
        /// <returns>
        /// true if the tree contains an element with the specified key and value; otherwise, false.
        /// </returns>        
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// throw new NotImplementedException();
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the tree.
        /// </summary>
        /// <param name="item">The object to remove from the tree.</param>
        /// <returns>
        /// true if item was successfully removed from the tree;
        /// otherwise, false. This method also returns false if item is not found in the original tree.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        /// The System.Collections.Generic.ICollection<T> is read-only.
        /// </exception>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the tree.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
