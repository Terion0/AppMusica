using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;


namespace AppMusica.PageModels
{

    [QueryProperty(nameof(Id), "id")]
    public partial class AlbumPageModel : ObservableObject
    {
        private readonly ServAlbum AlbumServices;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private AlbumReadExtended _selectedAlbum;

     
        public AlbumPageModel(ServAlbum servA)
        {
            AlbumServices = servA;  
        }
        partial void OnIdChanged(int value)
        {
            Sinchronize();
        }

        private async void Sinchronize()
        {
         
            var album = await AlbumServices.ReadAsync(Id);
            SelectedAlbum = album;
          
        }

        [RelayCommand]
        private async Task ToArtistAsync()
        {
            Debug.WriteLine(SelectedAlbum.ArtistId);
            await Shell.Current.GoToAsync($"detailartist?id={SelectedAlbum.ArtistId}");
        }
    }
}
