using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.DTO.Read
{
    public class ArtistRead : Artist
    {
        [JsonPropertyName("mbid")]
        public string? Mbid { get; set; }
        [JsonPropertyName("artist_background")]
        public string? ArtistBackground { get; set; }
        [JsonPropertyName("artist_logo")]
        public string? ArtistLogo { get; set; }
        [JsonPropertyName("artist_thumbnail")]
        public string? ArtistThumbnail { get; set; }
        [JsonPropertyName("artist_banner")]
        public string? ArtistBanner { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
