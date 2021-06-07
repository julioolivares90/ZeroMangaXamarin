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
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomePageViewModel(DependencyService.Get<IMangaRepository>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.onAppering();
        }
    }
}