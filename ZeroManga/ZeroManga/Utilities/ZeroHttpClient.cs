using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ZeroManga.Utilities
{
    public class ZeroHttpClient
    {
        private HttpClient _httpClient;

        public HttpClient GetHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(Constants.BASE_URL);

            }
            return _httpClient;
        }
    }
}
