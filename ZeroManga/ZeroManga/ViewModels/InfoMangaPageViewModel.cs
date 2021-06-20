using System;
using System.Collections.Generic;
using System.Text;
using ZeroManga.Services;
using Xamarin.Forms;

namespace ZeroManga.ViewModels
{
    [QueryProperty(nameof(Image),nameof(Image))]
    [QueryProperty(nameof(TitleM),nameof(TitleM))]
    [QueryProperty(nameof(Tipo),nameof(Tipo))]
    [QueryProperty(nameof(Score),nameof(Score))]
    [QueryProperty(nameof(Demografia),nameof(Demografia))]
    [QueryProperty(nameof(Estado),nameof(Estado))]
    [QueryProperty(nameof(Descripcion),nameof(Descripcion))]
    public class InfoMangaPageViewModel : BaseViewModel
    {
        //variables
        private string _image;
        private string _titleM;
        private string _tipo;
        private double _score;
        private string _demografia;
        private string _estado;
        //public List<string> _generos;
        private string _descripcion;


        //constructor
        public InfoMangaPageViewModel()
        {
            Title = "InfoManga";
            
        }

        //metodos setter y getter
        public string Image { get =>_image; set { SetProperty(ref _image, value); } }
        public string TitleM { get =>_titleM; set { SetProperty(ref _titleM, value); } }
        public string Tipo { get =>_tipo; set { SetProperty(ref _tipo, value); } }
        public double Score { get =>_score; set { SetProperty(ref _score, value); } }
        public string Demografia { get =>_demografia; set { SetProperty(ref _demografia, value); } }
        public string Estado { get =>_estado; set { SetProperty(ref _estado, value); } }
        public string Descripcion { get =>_descripcion; set { SetProperty(ref _descripcion, value); } }
    }
}
