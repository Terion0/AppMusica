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
    public class ServGenre
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializer;

        public ServGenre(HttpClient _client, JsonSerializerOptions _serializer)
        {
            client = _client;
            serializer = _serializer;
            
        }
        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenreRead>> ReadAllAsync()
        {
            List<GenreRead> fromApi = new();
         

            HttpResponseMessage response = await client.GetAsync("/genres");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = JsonSerializer.Deserialize<List<GenreRead>>(content, serializer);
            }
            return fromApi;
        }

        public async Task<GenreReadExtended> ReadAsync(int id)
        {
            GenreReadExtended fromApi = new();
            HttpResponseMessage response = await client.GetAsync($"/genres/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = fromApi = JsonSerializer.Deserialize<GenreReadExtended>(content, serializer);
            }

            return fromApi;
        }

        public void UpdateAsync(Genre objeto)
        {
            throw new NotImplementedException();
        }  
    }
}
