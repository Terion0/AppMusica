using AppMusica.PageModels;
using AppMusica.Pages;
using AppMusica.PagesModels;
using AppMusica.Services;
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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        JsonSerializerOptions serializer = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        builder.Services.AddSingleton<HttpClient>(); // Singleton porque  debe ser reutilizado
        builder.Services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        }); 
        builder.Services.AddTransient<ServSong>(); // Transient porque no mantiene estado
        builder.Services.AddTransient<ServArtist>(); 
        builder.Services.AddTransient<ServAlbum>(); 
        builder.Services.AddTransient<ServGenre>(); 
        builder.Services.AddTransient<MainPageModel>(); 
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AlbumPageModel>(); 
        builder.Services.AddTransient<AlbumPage>(); 
        builder.Services.AddTransient<SongsPageModel>(); 
        builder.Services.AddTransient<SongsPage>();
        builder.Services.AddTransient<ArtistPageModel>();
        builder.Services.AddTransient<ArtistPage>();
        builder.Services.AddTransient<AboutPageModel>();
        builder.Services.AddTransient<AboutPage>();


        return builder.Build();
	}
}
