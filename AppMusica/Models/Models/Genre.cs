﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMusica.Models.Models
{
    public class Genre
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
