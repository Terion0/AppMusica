using AppMusica.PageModels;
using AppMusica.PageModels.Detail;
using AppMusica.PageModels.Help;
using AppMusica.Pages;
using AppMusica.PagesModels;
using AppMusica.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AppMusica;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        
        builder.Services.AddSingleton( new HttpClient
        {
            BaseAddress = new Uri("http://localhost:8079")

        }); // Singleton porque  debe ser reutilizado
        builder.Services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            WriteIndented = true
        }); 
        builder.Services.AddTransient<ServSong>(); // Transient porque no mantiene estado
        builder.Services.AddTransient<ServArtist>(); 
        builder.Services.AddTransient<ServAlbum>(); 
        builder.Services.AddTransient<ServGenre>();
        builder.Services.AddTransient<ServPlaylist>();
        builder.Services.AddTransient<MainPageModel>(); 
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AlbumPageModel>(); 
        builder.Services.AddTransient<AlbumPage>(); 
        builder.Services.AddTransient<ArtistPageModel>();
        builder.Services.AddTransient<ArtistPage>();
        builder.Services.AddTransient<AboutPageModel>();
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<PlaylistPageModel>();
        builder.Services.AddTransient<PlaylistPage>();
       
        builder.Services.AddTransient<SettingsPageModel>();
        builder.Services.AddTransient<SettingsPage>();


        return builder.Build();
	}
}
