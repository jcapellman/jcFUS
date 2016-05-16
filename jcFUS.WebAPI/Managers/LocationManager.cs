using System;

using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Managers {
    public class LocationManager : BaseManager {
        public Guid? Create(string description) {
            using (var eFactory = new EFModel()) {
                var item = eFactory.LocationSet.Create();

                item.Description = description;

                eFactory.LocationSet.Add(item);

                var result = eFactory.SaveChanges();

                if (result > 0) {
                    return item.GUID;
                }

                return null;
            }
        }

        public Guid? AddUser(Guid locationGUID, Guid userGUID) {
            using (var eFactory = new EFModel()) {
                var locationRelation = eFactory.Users2LocationSet.Create();

                locationRelation.LocationGUID = locationGUID;
                locationRelation.UserGUID = userGUID;

                eFactory.Users2LocationSet.Add(locationRelation);

                var result = eFactory.SaveChanges();

                return result >= 0 ? (Guid?)locationRelation.GUID : null;
            }
        }
    }
}