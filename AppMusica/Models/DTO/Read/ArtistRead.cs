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
      
        public string? Mbid { get; set; }
       
        public string? ArtistBackground { get; set; }
       
        public string? ArtistLogo { get; set; }
       
        public string? ArtistThumbnail { get; set; }
       
        public string? ArtistBanner { get; set; }
       
        public int Id { get; set; }
    }
}
