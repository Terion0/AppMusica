using AppMusica.Services;
using AppMusica.Models.DTO.Read;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace AppMusica.PagesModels
{
   public partial class MainPageModel : ObservableObject
    {

        private readonly ServSong SongServices;
        private readonly ServArtist ArtistServices;
        private readonly ServAlbum AlbumServices;
        private readonly ServGenre GenreServices;



        [ObservableProperty]
        public ObservableCollection<SongRead> _listaCanciones= new();

        [ObservableProperty]
        private SongRead _selectedSong;

        [ObservableProperty]
        public ObservableCollection<ArtistRead> _ListaArtistas = new();

        [ObservableProperty]
        private ArtistRead _selectedArtist;

        [ObservableProperty]
        public ObservableCollection<AlbumRead> _ListaAlbumes = new();

        [ObservableProperty]
        private AlbumRead _selectedAlbum;

        [ObservableProperty]
        public ObservableCollection<GenreRead> _ListaGeneros = new();

        public MainPageModel(ServSong servS,ServArtist servA, ServAlbum servAl, ServGenre servG) {
                SongServices = servS;
                ArtistServices = servA;
                AlbumServices = servAl;
                GenreServices = servG;
                Sinchronice();
            }
           
              
                    

        private async void Sinchronice() {
            var aDevolverSongs = await SongServices.ReadAllAsync();
            ListaCanciones = new ObservableCollection<SongRead>(aDevolverSongs);

            var aDevolverArtist = await ArtistServices.ReadAllAsync();
            ListaArtistas = new ObservableCollection<ArtistRead>(aDevolverArtist);

            var aDevolverAlbum = await AlbumServices.ReadAllAsync();
            ListaAlbumes = new ObservableCollection<AlbumRead>(aDevolverAlbum);

            var aDevolverGenres = await GenreServices.ReadAllAsync();
            ListaGeneros = new ObservableCollection<GenreRead>(aDevolverGenres);
        }

       [RelayCommand]
       private async Task ToSongAsync() 
        { 
           await Shell.Current.GoToAsync($"detailsong?id={SelectedSong.Id}");
        }

        [RelayCommand]
        private async Task ToArtistAsync()
        {
            await Shell.Current.GoToAsync($"detailartist?id={SelectedArtist.Id}");
        }
        [RelayCommand]
        private async Task ToAlbumAsync()
        {
            await Shell.Current.GoToAsync($"detailalbum?id={SelectedAlbum.Id}");
        }

    }
}
