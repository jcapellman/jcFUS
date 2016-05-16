using jcFUS.PCL.Transports.Customer;

namespace jcFUS.WebAPI.Managers {
    public class CustomerManager : BaseManager {
        public bool Create(CustomerCreationRequestItem requestItem) {
            var locationGUID = new LocationManager().Create(requestItem.LocationName);

            if (!locationGUID.HasValue) {
                return false;
            }

            var roomGUID = new RoomManager().Create(requestItem.InitialRoomName);

            if (!roomGUID.HasValue) {
                return false;
            }

            requestItem.UserCreationRequestItem.HomeRoomGUID = roomGUID.Value;
            requestItem.UserCreationRequestItem.LocationGUID = locationGUID.Value;

            var userGUID = new UserManager().Create(requestItem.UserCreationRequestItem);

            return userGUID.HasValue;
        }
    }
}