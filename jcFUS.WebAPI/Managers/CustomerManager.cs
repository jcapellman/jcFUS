using jcFUS.PCL.Transports.Customer;
using jcFUS.PCL.Transports.Global;

namespace jcFUS.WebAPI.Managers {
    public class CustomerManager : BaseManager {
        public ReturnSet<bool> Create(CustomerCreationRequestItem requestItem) {
            var locationGUID = new LocationManager().Create(requestItem.LocationName);

            if (!locationGUID.HasValue) {
                return new ReturnSet<bool>(false);
            }

            var roomGUID = new RoomManager().Create(requestItem.InitialRoomName);

            if (!roomGUID.HasValue) {
                return new ReturnSet<bool>(false);
            }

            requestItem.UserCreationRequestItem.HomeRoomGUID = roomGUID.Value;
            requestItem.UserCreationRequestItem.LocationGUID = locationGUID.Value;

            var userGUID = new UserManager().Create(requestItem.UserCreationRequestItem);

            return new ReturnSet<bool>(userGUID.HasValue);
        }
    }
}