using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using jcFUS.PCL.Transports.TextChat;
using jcFUS.WebAPI.DataLayerLibrary.EFObjects;
using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Managers {
    public class TextChatManager : BaseManager {
        public async Task<List<TextChatLogResponseItem>> GetChatLogFromChannelAsync(Guid channelGUID) {
            using (var eFactory = new EFModel()) {
                var result =
                    await
                        eFactory.Database.SqlQuery<WEBAPI_getTextChatLogFromChannelSP>("WEBAPI_getTextChatLogFromChannelSP @ChannelGUID", new SqlParameter("@ChannelGUID", channelGUID.ToString())).ToListAsync();

                return result.Select(a => new TextChatLogResponseItem {
                    Entry = a.Entry,
                    Username = a.Username,
                    Timestamp = a.Timestamp
                }).ToList();
            }
        }
    }
}