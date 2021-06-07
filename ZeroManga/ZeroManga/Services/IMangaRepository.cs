using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeroManga.Models;

namespace ZeroManga.Services
{
    public interface IMangaRepository
    {
        Task<Response<List<Manga>>> GetMangasPopulares();
        Task<Response<List<Manga>>> GetMangasSeinenAsync();
        Task<Response<MangaInfo>> GetInfoManga(string urlManga);
    }
}
