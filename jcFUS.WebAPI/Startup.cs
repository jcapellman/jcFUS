using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(jcFUS.WebAPI.Startup))]
namespace jcFUS.WebAPI {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }
    }
}