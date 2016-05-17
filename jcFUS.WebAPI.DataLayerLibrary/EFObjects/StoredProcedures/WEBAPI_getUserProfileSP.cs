using System;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects {
    public class WEBAPI_getUserProfileSP {
        public string ColorString { get; set; }
        
        public string DisplayName { get; set; }
        
        public Guid DefaultChannelGUID { get; set; }

        public string Token { get; set; }
    }
}