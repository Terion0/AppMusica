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
    public class PlayListReadExtended : PlaylistRead
    {
        [JsonPropertyName("songs")]
        public SongRead[] Songs { get; set; }
    }
}
