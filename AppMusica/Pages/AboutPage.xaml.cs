using AppMusica.PageModels;
using AppMusica.PagesModels;


namespace AppMusica.Pages;
	
public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}