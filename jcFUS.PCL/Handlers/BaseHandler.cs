using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace jcFUS.PCL.Handlers {
    public abstract class BaseHandler {
        protected abstract string BaseControllerName();

        private HttpClient GetHttpClient() {
            var handler = new HttpClientHandler();

            return new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(1) };
        }

        private string generateURL(string arguments) => string.IsNullOrEmpty(arguments) ? $"{Common.Constants.WEBAPI_BASE_ADDRESS}{BaseControllerName()}" : $"{Common.Constants.WEBAPI_BASE_ADDRESS}{BaseControllerName()}?{arguments}";

        protected async Task<T> GetAsync<T>(string urlArguments) {
            var str = await GetHttpClient().GetStringAsync(generateURL(urlArguments));

            return JsonConvert.DeserializeObject<T>(str);
        }

        protected async void GetAsync(string urlArguments) {
            await GetHttpClient().GetStringAsync(generateURL(urlArguments));
        }

        private StringContent getStringContent<T>(T obj) => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

        protected async Task<TK> PostAsync<T, TK>(T obj) {
            var response = await GetHttpClient().PostAsync(generateURL(string.Empty), getStringContent(obj));

            var responseStr = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TK>(responseStr);
        }

        protected async Task<TK> PutAsync<T, TK>(string urlArguments, T obj) {
            var response = await GetHttpClient().PutAsync(generateURL(string.Empty), getStringContent(obj));

            var responseStr = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TK>(responseStr);
        }
    }
}