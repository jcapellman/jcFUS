using jcFUS.PCL.Transports.Users;

namespace jcFUS.PCL.Transports.Customer {
    public class CustomerCreationRequestItem {
        public string LocationName { get; set; }

        public string InitialRoomName { get; set; }

        public UserCreationRequestItem UserCreationRequestItem { get; set; }
    }
}