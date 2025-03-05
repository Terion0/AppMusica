using AppMusica.PagesModels;


namespace AppMusica.Pages;
	
public partial class SongsPage : ContentPage
{
	public SongsPage(SongsPageModel songsPage)
	{
		InitializeComponent();
		BindingContext = songsPage;
	}
}