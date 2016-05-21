using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using jcFUS.PCL.Transports.TextChat;
using jcFUS.WebAPI.Hubs;
using jcFUS.WebAPI.Managers;
using Microsoft.AspNet.SignalR;

namespace jcFUS.WebAPI.Controllers {
    public class TextChatController : BaseController {
        public async Task<List<TextChatLogResponseItem>> GET(Guid channelGUID)
            => await new TextChatManager(USER_GUID).GetChatLogFromChannelAsync(channelGUID);

        public async Task<bool> PUT(TextChatCreationRequestItem requestItem) {
            var result = await new TextChatManager(USER_GUID).PostTextChatAsync(requestItem);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TextChatHub>();
            hubContext.Clients.Group("TEST").send("Jarred", requestItem.Entry);

            return result;
        }
    }
}