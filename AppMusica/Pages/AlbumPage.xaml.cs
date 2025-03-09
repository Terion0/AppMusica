
using AppMusica.PageModels.Detail;



namespace AppMusica.Pages;
	
public partial class AlbumPage : ContentPage
{
	public AlbumPage(AlbumPageModel albumPage)
	{
		InitializeComponent();
		BindingContext = albumPage;
	}
}