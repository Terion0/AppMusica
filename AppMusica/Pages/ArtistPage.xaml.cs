


using AppMusica.PageModels.Detail;

namespace AppMusica.Pages;
	
public partial class ArtistPage : ContentPage
{
	public ArtistPage(ArtistPageModel artistPage)
	{
		InitializeComponent();
		BindingContext = artistPage;
	}
}