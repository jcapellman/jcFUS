using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using jcFUS.PCL.Transports.TextChat;
using jcFUS.WebAPI.Managers;

namespace jcFUS.WebAPI.Controllers {
    public class TextChatController : BaseController {
        public async Task<List<TextChatLogResponseItem>> GET(Guid channelGUID)
            => await new TextChatManager().GetChatLogFromChannelAsync(channelGUID);
    }
}