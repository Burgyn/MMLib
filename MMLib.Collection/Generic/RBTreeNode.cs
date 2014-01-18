using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.Collection.Generic
{
    /// <summary>
    /// This class represent one node from RB tree.
    /// </summary>
    internal class RBTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {

        #region Properties

        /// <summary>
        /// Get or set Key of node.
        /// </summary>
        public TKey Key
        {
            get;
            set;
        }


        /// <summary>
        /// Get or set value of node.
        /// </summary>
        public TValue Value
        {
            get;
            set;
        }


        /// <summary>
        /// Get or set color of node.
        /// </summary>
        public RBTreeColor Color
        {
            get;
            set;
        }


        /// <summary>
        /// Get or set left child of node.
        /// </summary>
        public RBTreeNode<TKey, TValue> LeftNode
        {
            get;
            set;
        }


        /// <summary>
        /// Get or ser right child of node.
        /// </summary>
        public RBTreeNode<TKey, TValue> RightNode
        {
            get;
            set;
        }


        /// <summary>
        /// Get or set parent of node.
        /// </summary>
        public RBTreeNode<TKey, TValue> Parent
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string that represents the current node.
        /// </summary>
        /// <returns>A string that represents the current node.</returns>
        public override string ToString()
        {
            return string.Format("Key: {0}; Value: {1}", Key, Value);
        }

        #endregion
    }

    /// <summary>
    /// Enum represent node color
    /// </summary>
    internal enum RBTreeColor
    {
        Red,
        Black,
    }
}
