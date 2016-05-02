using System;
using System.Runtime.Serialization;

namespace jcFUS.PCL.Transports.TextChat {
    [DataContract]
    public class TextChatCreationRequestItem {
        [DataMember]
        public Guid ChannelGUID { get; set; }

        [DataMember]
        public string Entry { get; set; }
    }
}