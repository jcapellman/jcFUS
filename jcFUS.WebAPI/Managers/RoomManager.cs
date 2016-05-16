using System;

using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Managers {
    public class RoomManager : BaseManager {
        public Guid? Create(string name) {
            using (var eFactory = new EFModel()) {
                var room = eFactory.RoomSet.Create();

                room.Description = name;

                eFactory.RoomSet.Add(room);

                var result = eFactory.SaveChanges();

                return result > 0 ? (Guid?)room.GUID : null;
            }
        }
    }
}