using AppMusica.PagesModels;

namespace AppMusica.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageModel mainPage)
        {
            InitializeComponent();
            BindingContext = mainPage;
        }

      
    }

}
