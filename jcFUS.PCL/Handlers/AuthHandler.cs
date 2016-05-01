using System.Threading.Tasks;

using jcFUS.PCL.Transports.Auth;

namespace jcFUS.PCL.Handlers {
    public class AuthHandler : BaseHandler {
        protected override string BaseControllerName() => "Auth";

        public async Task<AuthResponseItem> CheckAuthAsync(AuthRequestItem requestItem) => await PostAsync<AuthRequestItem, AuthResponseItem>(requestItem);
    }
}