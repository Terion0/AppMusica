using AppMusica.Models.DTO.Read;
using AppMusica.Models.DTO.ReadExtended;
using AppMusica.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppMusica.Services
{
    public class ServAlbum
    {

        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializer;

        public ServAlbum(HttpClient _client, JsonSerializerOptions _serializer)
        {
            client = _client;
            serializer = _serializer;
           
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<AlbumRead>> ReadAllAsync()
        {
            List<AlbumRead> fromApi = new();
            Uri uri = new Uri(string.Format("http://localhost:8079/albums", string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
               

                fromApi =  JsonSerializer.Deserialize<List<AlbumRead>>(content,serializer);
              
            }
            return fromApi;
        }

        public async Task<AlbumReadExtended> ReadAsync(int id)
        { 
            AlbumReadExtended fromApi = new();
            Uri uri = new Uri(string.Format($"http://localhost:8079/albums/{id}", string.Empty));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi  = JsonSerializer.Deserialize<AlbumReadExtended>(content, serializer);

            }
            return fromApi;
        }

        public void UpdateAsync(Album objeto)
        {
            throw new NotImplementedException();
        }



    
    }
}