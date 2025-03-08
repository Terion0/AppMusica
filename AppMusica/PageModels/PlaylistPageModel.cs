using AppMusica.Models.DTO.Read;
using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Models.Models;
using AppMusica.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusica.PageModels
{
    public partial class PlaylistPageModel : ObservableObject
    {
        private readonly ServSong SongServices;
        private readonly ServPlaylist PlaylistServices;
        private readonly HttpClient Dudacliente;

        [ObservableProperty]
        public ObservableCollection<SongRead> _listaCanciones = new();

        [ObservableProperty]
        public ObservableCollection<PlaylistRead> _listaPlaylits = new();

        [ObservableProperty]
        public PlaylistRead _selectedPlaylist;

        [ObservableProperty]
        public SongRead _selectedSong;



        [ObservableProperty]
        public SongRead _aReproducir;



        [ObservableProperty]
        public PlayListReadExtended aEscucharOCambiar;

        [ObservableProperty]
        public ObservableCollection<SongRead> _listaCanPlaylist = new();

        private string buscarCanciones;
        public string BuscarCanciones
        {
            get => buscarCanciones;
            set
            {
                if (buscarCanciones != value)
                {
                    buscarCanciones = value;
                    OnPropertyChanged();
                    FiltrarCanciones();

                }
            }
        }


        private string buscarPlaylists;
        public string BuscarPlaylists
        {
            get => buscarPlaylists;
            set
            {
                if (buscarPlaylists != value)
                {
                    buscarPlaylists = value;
                    OnPropertyChanged();
                    FiltrarPlaylists();

                }
            }
        }





        public PlaylistPageModel(ServSong song, ServPlaylist playlist, HttpClient client)
        {
            SongServices = song;
            PlaylistServices = playlist;
            Dudacliente = client;
            Sinchronice();
        }


        private async void Sinchronice()
        {
            var aDevolverSongs = await SongServices.ReadAllAsync();
            ListaCanciones = new ObservableCollection<SongRead>(aDevolverSongs);
          

            var aDevolverPlaylists = await PlaylistServices.ReadAllAsync();
            ListaPlaylits = new ObservableCollection<PlaylistRead>(aDevolverPlaylists);
        }

        private async void FiltrarCanciones()
        {
            if (string.IsNullOrEmpty(BuscarCanciones))
            {
                var aDevolverSongs = await SongServices.ReadAllAsync();
                ListaCanciones = new ObservableCollection<SongRead>(aDevolverSongs);
              
            }
            else
            {
                string lowerQuery = BuscarCanciones.ToLower();
                ListaCanciones = new ObservableCollection<SongRead>(
                    ListaCanciones.Where(c => c.Title.ToLower().Contains(lowerQuery)));
            }

        }


        private async void FiltrarPlaylists()
        {
            if (string.IsNullOrEmpty(BuscarPlaylists))
            {
                var aDevolverSongs = await PlaylistServices.ReadAllAsync();
                ListaPlaylits = new ObservableCollection<PlaylistRead>(aDevolverSongs);
            }
            else
            {
                string lowerQuery = BuscarPlaylists.ToLower();
                ListaPlaylits = new ObservableCollection<PlaylistRead>(
                    ListaPlaylits.Where(c => c.Title.ToLower().Contains(lowerQuery)));
            }

        }




        [RelayCommand]
        private async Task SacarPlaylistAsync()
        {
            var playlist = await PlaylistServices.ReadAsync(SelectedPlaylist.Id);
            AEscucharOCambiar = playlist;
            ListaCanPlaylist = new ObservableCollection<SongRead>(AEscucharOCambiar.Songs);

        }

        [RelayCommand]
        private async Task SacarCancion()
        {
            if (AEscucharOCambiar != null)
            {
                int idSong = SelectedSong.Id;
                int idPlaylist = aEscucharOCambiar.Id;
                await SongServices.UpdateAsync(idSong, idPlaylist);
                var songs = await SongServices.ReadAllAsync();
                List<SongRead> tmp = new();
          
                foreach (SongRead canciones in songs) {
                    SongReadExtended songDetail = await SongServices.ReadAsync(canciones.Id);
                    if (songDetail.Playlists == null) { songDetail.Playlists = new PlaylistRead[1];}
                    foreach (PlaylistRead pl in songDetail.Playlists) {
                        if (pl.Id == idPlaylist) {
                            tmp.Add(canciones);
                         
                        }
                    } 
                }
                ListaCanPlaylist = new ObservableCollection<SongRead>(tmp);
            }
        }



        [RelayCommand]
        private async Task GenerarPlaylistAsync() 
        {
            var devueltas = await PlaylistServices.ReadAllAsync();
            int cantPlaylist = devueltas.Count();
            Playlist nueva = new();
            nueva.Title = $"Playlists Nº{cantPlaylist}";
            nueva.Description = $"Esta es tu playlist numero {cantPlaylist}";
            await PlaylistServices.CreateAsync(nueva);

            var aDevolverPlaylists = await PlaylistServices.ReadAllAsync();
            ListaPlaylits = new ObservableCollection<PlaylistRead>(aDevolverPlaylists);
            cantPlaylist = ListaCanPlaylist.Count();
        }

        [RelayCommand]
        private async Task ReproduceSongAsync()
        {
            AppShell.CurrentInstance.PlaySong($"{Dudacliente.BaseAddress.ToString().TrimEnd('/')}{AReproducir.File}");

        }
    }  
}
