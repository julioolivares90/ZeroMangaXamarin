using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroManga.Models
{
    public class Response<T> 
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
