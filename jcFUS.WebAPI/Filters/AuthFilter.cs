using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using jcFUS.WebAPI.DataLayerLibrary.Entities;

namespace jcFUS.WebAPI.Filters {
    public class AuthFilter : DelegatingHandler {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.Headers.Contains("Token")) {
                using (var eFactory = new EFModel()) {
                    var userGUID =
                       await eFactory.Database.SqlQuery<Guid?>("WEBAPI_getUserGUIDFromTokenSP @Token",
                            new SqlParameter("@Token", request.Headers.GetValues("Token").FirstOrDefault()))
                            .FirstOrDefaultAsync(cancellationToken);

                    if (userGUID.HasValue) {
                        request.Properties.Add("UserGUID", userGUID.Value.ToString());
                    }
                }
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}