using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroManga.Models
{
    public class MangaResponse
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("data")]
        public List<Manga> Data { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }
    }
}
