using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Models
{
    /// <summary>
    /// Interface which reprezent one person.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// First name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last name.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Person's email.
        /// </summary>
        string Mail { get; }
    }
}
