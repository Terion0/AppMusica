using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.Models
{
     public class Song
    {
        [JsonPropertyName("title")]

        public string Title { get; set; }
        [JsonPropertyName("publisher")]

        public string? Publisher { get; set; }
        [JsonPropertyName("year")]

        public int? Year { get; set; }
        [JsonPropertyName("track_num")]

        public int? TrackNum { get; set; }
        [JsonPropertyName("album_id")]

        public int? AlbumId { get; set; }
        [JsonPropertyName("genre_id")]

        public int? GenreId { get; set; }
    }
}
