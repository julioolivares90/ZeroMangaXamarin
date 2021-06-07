using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroManga.Services;
using ZeroManga.ViewModels;

namespace ZeroManga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoMangaPage : ContentPage
    {
        private InfoMangaPageViewModel viewModel; 
        public InfoMangaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new InfoMangaPageViewModel(DependencyService.Get<IMangaRepository>());
        }
    }
}