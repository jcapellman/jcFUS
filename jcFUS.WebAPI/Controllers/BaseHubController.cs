using System;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace jcFUS.WebAPI.Controllers {
    public abstract class BaseHubController<THub> : BaseController where THub : IHub {
        readonly Lazy<IHubContext> hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<THub>());

        protected IHubContext Hub => hub.Value;
    }
}