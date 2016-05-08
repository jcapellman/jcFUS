using jcFUS.PCL.Common;

using Microsoft.AspNet.SignalR.Client;

namespace jcFUS.PCL.Hubs {
    public class ChatHub {
        private HubConnection _connection;

        private IHubProxy _chat;

        public ChatHub() {
            _connection = new HubConnection(Constants.WEBAPI_BASE_ADDRESS);

            _chat = _connection.CreateHubProxy("Chat");
        }
    }
}
