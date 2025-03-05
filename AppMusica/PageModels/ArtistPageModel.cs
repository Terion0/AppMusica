using AppMusica.Models.DTO.Read;
using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace AppMusica.PageModels
{
    [QueryProperty(nameof(Id), "id")]
    public partial class ArtistPageModel : ObservableObject
    {

        private readonly ServArtist ArtistServices;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private ArtistReadExtended _selectedArtist;

        [ObservableProperty]
        private AlbumRead _selectedAlbum;

        public ArtistPageModel(ServArtist servA)
        {
            ArtistServices = servA;
        }
        partial void OnIdChanged(int value)
        {
            Sinchronize();
        }

        private async void Sinchronize()
        {     
            var artist = await ArtistServices.ReadAsync(Id);
            SelectedArtist = artist;
        }

        [RelayCommand]
        private async Task ToAlbumAsync()
        {
            await Shell.Current.GoToAsync($"detailalbum?id={SelectedAlbum.Id}");
        }
    }
}
