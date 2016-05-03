using System;
using System.Web.Http;

namespace jcFUS.WebAPI.Controllers {
    [RoutePrefix("api/")]
    public class BaseController : ApiController {
        public Guid USER_GUID => Guid.Parse(Request.Properties["UserGUID"].ToString());
    }
}