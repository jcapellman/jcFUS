using System;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects {
    public class Users : BaseObject {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public Guid Password { get; set; }

        public bool IsActivated { get; set; }

        public DateTimeOffset? LastLogin { get; set; }

        public Guid HomeRoomGUID { get; set; }

        public string ProfileColor { get; set; }
    }
}