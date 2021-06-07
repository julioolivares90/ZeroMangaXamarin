using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroManga.Models;
using ZeroManga.Services;

namespace ZeroManga.ViewModels
{
    [QueryProperty(nameof(UrlManga), nameof(UrlManga))]
    public class DetailMangaPageViewModel : BaseViewModel
    {
        private readonly IMangaRepository mangaRepository;

        public string urlManga { get; set; }

        public string title { get; set; }

        public string Descripcion { get; set; }

        public string Demografia { get; set; }

        public string Estado { get; set; }

        public List<string> Generos { get; set; }

        public string ImageUrl { get; set; }

        public double Score { get; set; }

        public string Tipo { get; set; }

        public List<Capitulo> Capitulos { get; set; }

        public Command BackCommand { get; }

        public DetailMangaPageViewModel(IMangaRepository mangaRepository)
        {
            this.mangaRepository = mangaRepository;
            BackCommand = new Command( async () => await ExecuteBackCommand());
        }

        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("..");
        }

        public string UrlManga
        { 
            get => urlManga;
            set
            {
                urlManga = value;
                LoadDataFromUrl(UrlManga);
            }
        }


        public async void LoadDataFromUrl(string url)
        {
            try
            {
                var item = await mangaRepository.GetInfoManga(url);

                if (item != null && item.StatusCode == 200)
                {
                    title = item.Data.Title;
                    Descripcion = item.Data.Description;
                    Demografia = item.Data.Demografia;
                    Estado = item.Data.Estado;
                    Generos = item.Data.Generos;
                    ImageUrl = item.Data.ImageUrl;
                    Score = item.Data.Score;
                    Tipo = item.Data.Tipo;
                    Capitulos = item.Data.Capitulos;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"{ex.Message}");
            }
        }
    }
}
