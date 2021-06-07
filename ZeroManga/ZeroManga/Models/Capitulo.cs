using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroManga.Models
{
    public class Capitulo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("urlLeer")]
        public string UrlLeer { get; set; }
    }
}
