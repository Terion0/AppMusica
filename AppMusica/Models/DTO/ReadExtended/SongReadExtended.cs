using AppMusica.Models.DTO.Read;
using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.DTO.ReadExtended
{
    public class SongReadExtended : SongRead
    {
        [JsonPropertyName("album")]
        public AlbumReadExtended Album { get; set; }
        [JsonPropertyName("genre")]
        public GenreRead Genre { get; set; }
        [JsonPropertyName("playlists")]
        public PlaylistRead [] Playlist { get; set; }
    }
}
