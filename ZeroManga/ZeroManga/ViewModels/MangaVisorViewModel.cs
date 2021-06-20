using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZeroManga.ViewModels
{
    [QueryProperty(nameof(UrlRefer),nameof(UrlRefer))]
    [QueryProperty(nameof(UrlCapitulo),nameof(UrlCapitulo))]
    public class MangaVisorViewModel : BaseViewModel
    {

        //constructor
        public MangaVisorViewModel()
        {
            _imagenes = new List<string>();
        }
        //variables locales
        private string _urlRefer;
        private string _urlCapitulo;
        private List<string> _imagenes;

        //setter and getters
        public string UrlRefer { get => _urlRefer; set 
            {
                if (value != null)
                {
                    SetProperty(ref _urlRefer,value);
                }
            }
        }

        public string UrlCapitulo { get=> _urlCapitulo; set 
            {
                if (value != null)
                {
                    SetProperty(ref _urlCapitulo,value);
                }
            }
        }

        public List<string> Imagenes { get => _imagenes; set { SetProperty(ref _imagenes, value); } }

        //commands
    }
}
