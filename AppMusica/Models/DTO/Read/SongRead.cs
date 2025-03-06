using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.DTO.Read
{
    public class SongRead : Song
    {
      
        public string File { get; set; }
      
        public int Id { get; set; }
    }
}
