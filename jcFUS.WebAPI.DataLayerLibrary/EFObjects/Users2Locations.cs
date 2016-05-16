using System;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects {
    public class Users2Locations : BaseObject {
        public Guid UserGUID { get; set; }

        public Guid LocationGUID { get; set; }
    }
}