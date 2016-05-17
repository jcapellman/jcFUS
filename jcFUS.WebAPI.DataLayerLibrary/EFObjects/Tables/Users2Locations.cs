using System;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects.Tables {
    public class Users2Locations : BaseTableObject {
        public Guid UserGUID { get; set; }

        public Guid LocationGUID { get; set; }
    }
}