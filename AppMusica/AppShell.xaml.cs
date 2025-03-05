using AppMusica.Pages;
using AppMusica.PagesModels;

namespace AppMusica
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeRouting();
        }

        static void InitializeRouting()
        {
            Routing.RegisterRoute("detailsong", typeof(SongsPage));
            Routing.RegisterRoute("detailalbum", typeof(AlbumPage));
            Routing.RegisterRoute("detailartist", typeof(ArtistPage));

        }
    }
}
