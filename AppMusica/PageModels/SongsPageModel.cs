using CommunityToolkit.Mvvm.ComponentModel;
using AppMusica.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMusica.Models;
using AppMusica.Models.DTO.ReadExtended;
using System.Diagnostics;

namespace AppMusica.PagesModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class SongsPageModel : ObservableObject
    {
        private readonly ServSong SongServices;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private SongReadExtended selectedSong;


        public SongsPageModel(ServSong servS)
        {

            SongServices = servS;
            Sinchronize();
        }
        private async void Sinchronize() {
            var song = await SongServices.ReadAsync(Id);
            SelectedSong = song;
            Debug.WriteLine(SelectedSong.File);

        
        }
    }
}

