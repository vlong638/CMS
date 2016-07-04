using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1.Entities
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name{ get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
