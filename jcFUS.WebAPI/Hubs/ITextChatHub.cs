using jcFUS.PCL.Transports.TextChat;

using Microsoft.AspNet.SignalR;

namespace jcFUS.WebAPI.Hubs {
    public class TextChatHub : Hub {
        public void Send(TextChatCreationRequestItem requestItem) {
            Clients.All.SendTextChatToClients("Jarred", requestItem.Entry);
        }
    }
}