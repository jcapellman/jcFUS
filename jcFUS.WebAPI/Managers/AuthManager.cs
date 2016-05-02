using System.Data.SqlClient;
using System.Threading.Tasks;

using jcFUS.PCL.Transports.Auth;
using jcFUS.WebAPI.DataLayerLibrary.EFObjects;
using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Managers {
    public class AuthManager : BaseManager {
        public async Task<AuthResponseItem> CheckAuthAsync(AuthRequestItem requestItem) {
            using (var eFactory = new EFModel()) {
                var result =
                    await eFactory.Database.SqlQuery<WEBAPI_getUserProfileSP>("WEBAPI_getUserProfileSP @Username, @Password",
                        new SqlParameter("@Username", requestItem.Username),
                        new SqlParameter("@Password", requestItem.Password)).FirstOrDefaultAsync();

                if (result == null) {
                    return null;
                }

                return new AuthResponseItem {
                    ColorString = result.ColorString,
                    DisplayName = result.DisplayName,
                    DefaultChannelGUID = result.DefaultChannelGUID,
                    Token = result.Token
                };
            }
        }
    }
}