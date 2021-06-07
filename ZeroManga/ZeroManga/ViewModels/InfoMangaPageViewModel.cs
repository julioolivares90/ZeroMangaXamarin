using System;
using System.Collections.Generic;
using System.Text;
using ZeroManga.Services;

namespace ZeroManga.ViewModels
{
    public class InfoMangaPageViewModel : BaseViewModel
    {
        private readonly IMangaRepository repository;

        public InfoMangaPageViewModel(IMangaRepository repository)
        {
            Title = "InfoManga";
            this.repository = repository;
        }
    }
}
