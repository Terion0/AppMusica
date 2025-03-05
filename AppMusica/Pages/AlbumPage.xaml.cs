using AppMusica.PageModels;
using AppMusica.PagesModels;


namespace AppMusica.Pages;
	
public partial class AlbumPage : ContentPage
{
	public AlbumPage(AlbumPageModel albumPage)
	{
		InitializeComponent();
		BindingContext = albumPage;
	}
}