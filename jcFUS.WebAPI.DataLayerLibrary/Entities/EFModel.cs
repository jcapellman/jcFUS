using System.Data.Entity;

namespace jcFUS.WebAPI.DataLayerLibrary.Entities {    
    public class EFModel : DbContext {
        public EFModel() : base("name=EFModel") { }
    }
}