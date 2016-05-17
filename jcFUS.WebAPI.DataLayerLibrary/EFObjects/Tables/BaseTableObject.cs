using System;
using System.ComponentModel.DataAnnotations;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects.Tables {
    public class BaseTableObject {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }
    }
}