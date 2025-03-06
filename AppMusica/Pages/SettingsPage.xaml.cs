using AppMusica.PageModels;
using AppMusica.PagesModels;


namespace AppMusica.Pages;
	
public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}