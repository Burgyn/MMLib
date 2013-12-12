using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Models
{
    /// <summary>
    /// Class represent person.
    /// </summary>
    public class Person : IPerson
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person's email.
        /// </summary>
        public string Mail { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, LastName, Mail);
        }
    }
}
