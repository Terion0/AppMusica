
using AppMusica.PageModels.Help;



namespace AppMusica.Pages;
	
public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}