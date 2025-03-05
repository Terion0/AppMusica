using AppMusica.PageModels;
using AppMusica.PagesModels;


namespace AppMusica.Pages;
	
public partial class ArtistPage : ContentPage
{
	public ArtistPage(ArtistPageModel artistPage)
	{
		InitializeComponent();
		BindingContext = artistPage;
	}
}