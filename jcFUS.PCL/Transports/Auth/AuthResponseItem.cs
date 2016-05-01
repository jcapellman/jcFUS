using System;
using System.Runtime.Serialization;

namespace jcFUS.PCL.Transports.Auth {
    [DataContract]
    public class AuthResponseItem {
        [DataMember]
        public string ColorString { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public Guid DefaultChannelGUID { get; set; }
    }
}