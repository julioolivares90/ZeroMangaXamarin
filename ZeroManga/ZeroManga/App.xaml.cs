using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroManga.Services;
using ZeroManga.Views;


namespace ZeroManga
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IMangaRepository, MangaRepository>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
