using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace jcFUS.WebAPI.Hubs {
    [HubName("textChat")]
    public class TextChatHub : Hub {
        public void Send(string username, string entry) {
            Clients.All.sendTextChatToClients(username, entry);
        }
    }
}