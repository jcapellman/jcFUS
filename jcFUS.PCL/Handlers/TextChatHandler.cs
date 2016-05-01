using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using jcFUS.PCL.Transports.TextChat;

namespace jcFUS.PCL.Handlers {
    public class TextChatHandler : BaseHandler {
        protected override string BaseControllerName() => "TextChat";

        public async Task<List<TextChatLogResponseItem>> GetTextChatLogFromChannelAsync(Guid channelGUID) => await GetAsync<List<TextChatLogResponseItem>>($"channelGUID={channelGUID}");
    }
}