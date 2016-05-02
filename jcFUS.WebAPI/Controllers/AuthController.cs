using System.Threading.Tasks;

using jcFUS.PCL.Transports.Auth;
using jcFUS.WebAPI.Managers;

namespace jcFUS.WebAPI.Controllers {
    public class AuthController : BaseController {
        public async Task<AuthResponseItem> POST(AuthRequestItem requestItem) => await new AuthManager().CheckAuthAsync(requestItem);
    }
}