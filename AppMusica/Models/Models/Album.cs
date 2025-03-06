using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.Models
{
    public class Album
    {
      
        public string Title { get; set; }
      
        public int? Year { get; set; }
       
        public string? Picture { get; set; }
      
        public int? ArtistId { get; set; }
    }
}
