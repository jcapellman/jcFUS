using System;

namespace jcFUS.PCL.Transports.Users {
    public class UserCreationRequestItem {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public Guid Password { get; set; }

        public string ProfileColor { get; set; }

        public Guid HomeRoomGUID { get; set; }

        public Guid LocationGUID { get; set; }
    }
}