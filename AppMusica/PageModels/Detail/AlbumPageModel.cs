using AppMusica.Models.DTO.Read;
using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace AppMusica.PageModels
{

    [QueryProperty(nameof(Id), "id")]
    public partial class AlbumPageModel : ObservableObject
    {
        private readonly ServAlbum AlbumServices;

        private readonly HttpClient DudaCliente;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private AlbumReadExtended _selectedAlbum;

        [ObservableProperty]
        private SongRead _selectedSong;

        [ObservableProperty]
        public ObservableCollection<SongRead> _listaCanciones = new();


        public AlbumPageModel(ServAlbum servA, HttpClient client)
        {
            DudaCliente = client;
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
            ListaCanciones = new ObservableCollection<SongRead>(SelectedAlbum.Songs); 
          
        }

        [RelayCommand]
        private async Task ToArtistAsync()
        {
            Debug.WriteLine(SelectedAlbum.ArtistId);
            await Shell.Current.GoToAsync($"detailartist?id={SelectedAlbum.ArtistId}");
        }

        [RelayCommand]
        private async Task ReproduceSong()
        {
            AppShell.CurrentInstance.PlaySong($"{DudaCliente.BaseAddress.ToString().TrimEnd('/')}{SelectedSong.File}");
           
        }
    }
}
