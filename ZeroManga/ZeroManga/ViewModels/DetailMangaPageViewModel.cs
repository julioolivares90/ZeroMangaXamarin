using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using ZeroManga.Models;
using ZeroManga.Services;
using ZeroManga.Views;

namespace ZeroManga.ViewModels
{
    [QueryProperty(nameof(UrlManga), nameof(UrlManga))]
    public class DetailMangaPageViewModel : BaseViewModel
    {
        private readonly IMangaRepository mangaRepository;

        private int _currentImage;

        private string _urlManga;

        private string _title;

        private string _Descripcion;

        private string _Demografia;

        private string _Estado;

        private List<string> _Generos;

        private string _imageUrl;

        private double _Score;

        private string _Tipo;

        private List<Capitulo> _Capitulos;

        public Command BackCommand { get; }
        public Command<Capitulo> ItemTapped { get; }

        public Command FavoritosCommand { get; }

        public Command MoreInfoTapped { get; }
        private LayoutState _mainState;

        public LayoutState MainState
        {
            get => _mainState;
            set => SetProperty(ref _mainState, value);
        }

        public DetailMangaPageViewModel(IMangaRepository mangaRepository)
        {
            this.mangaRepository = mangaRepository;
            BackCommand = new Command( async () => await ExecuteBackCommand());
            ItemTapped = new Command<Capitulo>(OnItemSelected);
            MoreInfoTapped = new Command(OnMoreInfoTapped);
            FavoritosCommand = new Command(OnFavoritosTapped);
            
        }

        private async void OnMoreInfoTapped(object obj)
        {
            var navigateTo = $"{nameof(InfoMangaPage)}?{nameof(InfoMangaPageViewModel.Image)}={ImagenUrl}&{nameof(InfoMangaPageViewModel.TitleM)}={TitleM}&{nameof(InfoMangaPageViewModel.Tipo)}={Tipo}&{nameof(InfoMangaPageViewModel.Score)}={Score}&{nameof(InfoMangaPageViewModel.Demografia)}={Demografia}&{nameof(InfoMangaPageViewModel.Estado)}={Estado}&{nameof(InfoMangaPageViewModel.Descripcion)}={Descripcion}";
            await Shell.Current.GoToAsync(navigateTo);
        }

        private void OnFavoritosTapped(object obj)
        {
            // TODO programar insertar en base de datos sqlite
        }

        private async void OnItemSelected(Capitulo capitulo)
        {
            if (capitulo == null)
            {
                return;
            }
            Debug.WriteLine(capitulo.Name);

            try
            {
                var navigateTo = $"{nameof(MangaVisorViewModel)}?{nameof(MangaVisorViewModel.UrlRefer)}=${UrlManga}&{nameof(MangaVisorViewModel.UrlCapitulo)}={capitulo.UrlLeer}";
                await Shell.Current.GoToAsync(navigateTo);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
        }
        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("..");
        }
        public string ImagenUrl { get=> _imageUrl; 
            set
            {
                _imageUrl = value;
                SetProperty(ref _imageUrl, value);
            }
        }
        public string UrlManga
        { 
            get => _urlManga;
            set
            {
                //_urlManga = value;
                SetProperty(ref _urlManga, value);
                LoadDataFromUrl(UrlManga);
            }
        }
        public string TitleM { get => _title; set { SetProperty(ref _title, value); } }
        public string Descripcion { get => _Descripcion; set { SetProperty(ref _Descripcion, value); } }
        public string Demografia { get => _Demografia; set { SetProperty(ref _Demografia, value); } }
        public string Estado { get => _Estado; set { SetProperty(ref _Estado,value); } }
        public List<string> Generos { get => _Generos; set { SetProperty(ref _Generos, value); } }
        public string imageUrl { get => _imageUrl; set { SetProperty(ref _imageUrl, value); } }
        public double Score { get => _Score; set { SetProperty(ref _Score, value); } }
        public string Tipo { get => _Tipo; set { SetProperty(ref _Tipo,value);  } }
        public List<Capitulo> Capitulos { get => _Capitulos; set { SetProperty(ref _Capitulos, value); } }
        public int CurrentImage
        {
            get { return _currentImage; }
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }
        public async void LoadDataFromUrl(string url)
        {
            try
            {
                var item = await mangaRepository.GetInfoManga(url);

                if (item != null && item.StatusCode == 200)
                {
                    TitleM = item.Data.Title;
                    Descripcion = item.Data.Description;
                    Demografia = item.Data.Demografia;
                    Estado = item.Data.Estado;
                    Generos = item.Data.Generos;
                    imageUrl = item.Data.ImageUrl;
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
