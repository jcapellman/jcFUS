using System;
using System.Runtime.Serialization;

namespace jcFUS.PCL.Transports {
    [DataContract]
    public class ChatLogItem {
        [DataMember]
        public string Entry { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }
    }
}