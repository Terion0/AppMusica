using AppMusica.Models.DTO.Read;
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
    public class ServArtist
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializer;

        public ServArtist(HttpClient _client, JsonSerializerOptions _serializer)
        {
            client = _client;
            serializer = _serializer;
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArtistRead>> ReadAllAsync()
        {
            List<ArtistRead> fromApi = new();
       

            HttpResponseMessage response = await client.GetAsync("/artists");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                fromApi = JsonSerializer.Deserialize<List<ArtistRead>>(content, serializer);

            }
            return fromApi;
        }

        public async Task<ArtistReadExtended> ReadAsync(int id)
        {
            ArtistReadExtended fromApi = new();
         
            HttpResponseMessage response = await client.GetAsync($"/artists/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = fromApi = JsonSerializer.Deserialize<ArtistReadExtended>(content, serializer);

            }

            return fromApi;
        }

        public void UpdateAsync(Artist objeto)
        {
            throw new NotImplementedException();
        }

    }
}
