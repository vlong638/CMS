using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WpfApplication2.Entity
{
    [DataContract]
    public class SerialConstruct
    {
        [DataMember]
        internal string SerialKey;

        [DataMember]
        internal string ModuleName;

        [DataMember]
        internal string PreCode;

        [DataMember]
        internal string IndexCode;

        [DataMember]
        internal string DateFormat;

        [DataMember]
        internal string Sepa;
    }

}
