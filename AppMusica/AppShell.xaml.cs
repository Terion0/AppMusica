using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Pages;
using AppMusica.PagesModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppMusica
{
    public partial class AppShell : Shell
    {
        public static AppShell CurrentInstance { get; private set; }


        public AppShell()
        {
            InitializeComponent();
            InitializeRouting();
            CurrentInstance = this;
        }

        static void InitializeRouting()
        {
     
            Routing.RegisterRoute("detailalbum", typeof(AlbumPage));
            Routing.RegisterRoute("detailartist", typeof(ArtistPage));


        }

        public void PlaySong(string UriCancion)
        { 
                Reproductor.IsVisible = true;
                Reproductor.Source = UriCancion; 
                Reproductor.Play();
          
         
        }
    }
}
