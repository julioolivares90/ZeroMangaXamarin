using System;
using System.Collections.Generic;
using System.Text;
using ZeroManga.Models;
using ZeroManga.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using ZeroManga.Views;

namespace ZeroManga.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly IMangaRepository _repository;

        ObservableCollection<ItemManga> mangasPopulares;

        ObservableCollection<ItemManga> mangasSeinen;

        public Command LoadMangas { get; }

        //public Command LoadMangasSeinenCommand { get; }

        public Command<ItemManga> ItemTapped { get; }

        private ItemManga _selectedItem;

        public HomePageViewModel(IMangaRepository repository)
        {
            Title = "Home";
            _repository = repository;
            mangasPopulares = new ObservableCollection<ItemManga>();
            mangasSeinen = new ObservableCollection<ItemManga>();
            LoadMangas = new Command(async () => await ExecuteLoadMangasCommand());
            //LoadMangasSeinenCommand = new Command(async () => await ExecuteLoadMangasSeinenCommand());
            ItemTapped = new Command<ItemManga>(onItemSelected);

            
            
        }

        private async Task ExecuteLoadMangasSeinenCommand()
        {
           await LoadMangasSeinen();
        }
        public async Task LoadMangasSeinen()
        {
            try
            {
                var data = await _repository.GetMangasSeinenAsync();
                foreach (var item in data.Data)
                {
                    var itemManga = new ItemManga();

                    itemManga.Title = item.Title;
                    itemManga.MangaImagen = item.MangaImagen;
                    itemManga.MangaUrl = item.MangaUrl;
                    itemManga.Score = item.Score;
                    itemManga.Type = item.Type;
                    itemManga.Demography = item.Demography;
                    itemManga.Color = Color.FromHex("#90d32f2f");

                    mangasSeinen.Add(itemManga);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {

            }
        }
        private async Task ExecuteLoadMangasCommand()
        {
            IsBusy = true;
            try
            {
                
                var data = await _repository.GetMangasPopulares();

                foreach (var item in data.Data)
                {
                    Console.WriteLine($"Title: {item.Title}");
                    var itemManga = new ItemManga();

                    itemManga.Title = item.Title;
                    itemManga.MangaImagen = item.MangaImagen;
                    itemManga.MangaUrl = item.MangaUrl;
                    itemManga.Score = item.Score;
                    itemManga.Type = item.Type;
                    itemManga.Demography = item.Demography;
                    switch (item.Demography.ToLower())
                    {
                        case "shounen":
                            itemManga.Color = Color.FromHex("#E2E912");
                            break;
                        case "seinen":
                            itemManga.Color = Color.FromHex("#90d32f2f");
                            break;
                        case "josei":
                            itemManga.Color = Color.FromHex("#8e24aa");
                            break;
                        case "shoujo":
                            itemManga.Color = Color.FromHex("#f06292");
                            break;
                        default:
                            itemManga.Color = Color.FromHex("#243547");
                            break;
                    }

                    mangasPopulares.Add(itemManga);
                   await LoadMangasSeinen();
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }finally
            {
                IsBusy = false;
            }
        }

        private async void onItemSelected(ItemManga item)
        {
            if (item == null)
            {
                return;
            }
            //enviar a pagina de detalle
            Debug.WriteLine(item.Title);
            try
            {
                var navegateTo = $"{nameof(DetailManga)}?{nameof(DetailMangaPageViewModel.UrlManga)}={item.MangaUrl}";
                await Shell.Current.GoToAsync(navegateTo);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
        }

        public void onAppering()
        {

            IsBusy = true;
            SelectedItem = null;
        }

        public ObservableCollection<ItemManga> MangasPopulares
        {
            get => mangasPopulares;
            set
            {
                if (value != null)
                {
                    SetProperty(ref mangasPopulares, value);
                    OnPropertyChanged(nameof(mangasPopulares));
                }
               
            }
        }
        public ObservableCollection<ItemManga> MangasSeinen
        {
            get => mangasSeinen;
            set
            {
                if (value != null)
                {
                    SetProperty(ref mangasSeinen, value);
                    OnPropertyChanged(nameof(mangasSeinen));
                       
                }
            }
        }
        public ItemManga SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                onItemSelected(value);
            }
        }
    }
}
