using System;

using jcFUS.PCL.Transports.Users;
using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Managers {
    public class UserManager : BaseManager {
        public Guid? Create(UserCreationRequestItem requestItem) {
            using (var eFactory = new EFModel()) {
                var user = eFactory.UserSet.Create();

                user.DisplayName = requestItem.DisplayName;
                user.EmailAddress = requestItem.EmailAddress;
                user.HomeRoomGUID = requestItem.HomeRoomGUID;
                user.IsActivated = false;
                user.LastLogin = null;
                user.Password = requestItem.Password;
                user.ProfileColor = requestItem.ProfileColor;

                eFactory.UserSet.Add(user);

                var result = eFactory.SaveChanges();

                if (result <= 0) {
                    return null;
                }

                var locationResult = new LocationManager().AddUser(requestItem.LocationGUID, user.GUID);

                if (locationResult.HasValue) {
                    return user.GUID;
                }

                return null;
            }
        }
    }
}