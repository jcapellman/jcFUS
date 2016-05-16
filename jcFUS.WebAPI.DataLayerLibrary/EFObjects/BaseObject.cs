using System;
using System.ComponentModel.DataAnnotations;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects {
    public class BaseObject {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }
    }
}