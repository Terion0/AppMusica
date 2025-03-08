using AppMusica.PageModels;

namespace AppMusica.Pages;

public partial class PlaylistPage : ContentPage
{
	public PlaylistPage(PlaylistPageModel model)
	{
        BindingContext = model;
        InitializeComponent();
	}
}