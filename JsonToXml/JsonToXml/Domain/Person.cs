using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonToXml.Domain
{
    /// <summary>
    /// A representation of a person
    /// </summary>
    [DataContract]
    internal class Person
    {
        /// <summary>
        /// The Name of the person
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// The Date of birth for the person
        /// </summary>
        [DataMember(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
