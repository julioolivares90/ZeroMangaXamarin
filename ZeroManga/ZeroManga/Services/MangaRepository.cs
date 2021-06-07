using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZeroManga.Models;
using ZeroManga.Utilities;

namespace ZeroManga.Services
{

    public class MangaRepository : IMangaRepository
    {
        public async Task<Response<MangaInfo>> GetInfoManga(string urlManga)
        {
            ApiHelper.Instanse.Init();
            var result = await ApiHelper.Instanse.Get<Response<MangaInfo>>($"{Constants.MANGA_INFO}{urlManga}");
            if (result.StatusCode == (int) HttpStatusCode.OK)
            {
                return result;
            }
            return default;
        }

        public async Task<Response<List<Manga>>> GetMangasPopulares()
        {
            ApiHelper.Instanse.Init();
            var result = await ApiHelper.Instanse.Get<Response<List<Manga>>>(Constants.MANGAS_POPULARES);

            if (result.StatusCode == (int) HttpStatusCode.OK)
            {
                return result;
            }
            return default;
        }

        public async Task<Response<List<Manga>>> GetMangasSeinenAsync()
        {
            var result = await ApiHelper.Instanse.Get<Response<List<Manga>>>(Constants.MANGAS_SEINEN);

            if (result.StatusCode == (int) HttpStatusCode.OK)
            {
                return result;
            }
            return default;
        }
    }
}
