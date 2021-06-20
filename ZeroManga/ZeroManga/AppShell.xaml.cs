using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZeroManga.ViewModels;
using ZeroManga.Views;

namespace ZeroManga
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DetailManga), typeof(DetailManga));
            Routing.RegisterRoute(nameof(InfoMangaPage), typeof(InfoMangaPage));
            Routing.RegisterRoute(nameof(MangaVisorPage), typeof(MangaVisorPage)) ;
        }

    }
}
