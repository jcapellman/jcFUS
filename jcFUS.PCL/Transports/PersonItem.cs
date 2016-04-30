using System;
using System.Runtime.Serialization;

namespace jcFUS.PCL.Transports {
    [DataContract]
    public class PersonItem {
        [DataMember]
        public Guid GUID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Color { get; set; }
    }
}