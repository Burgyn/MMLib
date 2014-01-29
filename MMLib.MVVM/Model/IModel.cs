using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.Model
{
    /// <summary>
    /// Interface, which represent model.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Uniq identifier.
        /// </summary>
        int Id { get; set; }
    }
}
