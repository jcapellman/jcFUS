using System;

using jcFUS.WebAPI.Hubs;

namespace jcFUS.WebAPI.Managers {
    public class BaseManager {
        protected TextChatHub TCHub;

        protected Guid _userGUID;

        public BaseManager() { }

        public BaseManager(Guid userGUID) {
            TCHub = new TextChatHub();

            _userGUID = userGUID;
        }
    }
}