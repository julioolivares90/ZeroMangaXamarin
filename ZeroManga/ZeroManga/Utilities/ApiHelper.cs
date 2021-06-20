using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZeroManga.Utilities
{
    public class ApiHelper
    {
        private static ApiHelper _instanse;

        private HttpClient _httpClient;

        static ApiHelper()
        {
            _instanse = _instanse ?? new ApiHelper();
        }

        public void Init()
        {
            _httpClient = new HttpClient() 
            {
                BaseAddress = new Uri(Constants.BASE_URL)
            };
        }

        public static ApiHelper Instanse
        {
            get => _instanse;
        }

        public async Task<T> Get<T>(string url)
        {
            using (var response = await _httpClient.GetAsync(url.Trim()))
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                Debug.WriteLine(result);
                if (response.StatusCode != System.Net.HttpStatusCode.BadGateway || response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    var r = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
                    return r;
                }
            }
            return default;
        }
    }
}
