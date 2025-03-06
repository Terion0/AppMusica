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

        public string Title { get; set; }

       
        public string? Publisher { get; set; }


    
        public int? Year { get; set; }

        public int? TrackNum { get; set; }

    
        public int? AlbumId { get; set; }

        public int? GenreId { get; set; }
    }
}
