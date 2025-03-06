﻿using AppMusica.Models.DTO.Read;
using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppMusica.Services
{
    public class ServSong
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializer;

        public ServSong(HttpClient _client, JsonSerializerOptions _serializer)
        {
            client = _client;
            serializer = _serializer;
        }

        public async Task<List<SongRead>> ReadAllAsync()
        {
            List<SongRead> fromApi = new();
            Uri uri = new Uri(string.Format("http://localhost:8079/songs", string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                fromApi = JsonSerializer.Deserialize<List<SongRead>>(content, serializer);

            }
            return fromApi;
        }

        public async Task<SongReadExtended> ReadAsync(int id)
        {
            SongReadExtended fromApi = new();
            Uri uri = new Uri(string.Format($"http://localhost:8079/{id}", string.Empty));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = fromApi = JsonSerializer.Deserialize<SongReadExtended>(content, serializer);

            }

            return fromApi;
        }


    }
}
