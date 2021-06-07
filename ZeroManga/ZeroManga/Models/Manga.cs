using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroManga.Models
{
    public class Manga
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("mangaUrl")]
        public string MangaUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("demography")]
        public string Demography { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("mangaImagen")]
        public string MangaImagen { get; set; }
    }
}
