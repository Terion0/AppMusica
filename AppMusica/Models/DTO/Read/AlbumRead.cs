using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.DTO.Read
{
    public class AlbumRead : Album
    {

        [JsonPropertyName("mbid")]
        public int? Mbid { get; set; }


        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
