using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroManga.Models
{
    public class MangaInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("demografia")]
        public string Demografia { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("generos")]
        public List<string> Generos { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("capitulos")]
        public List<Capitulo> Capitulos { get; set; }
    }
}
