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
    public class ServPlaylist
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializer;

        public ServPlaylist(HttpClient _client, JsonSerializerOptions _serializer)
        {
            client = _client;
            serializer = _serializer;
        }
        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlaylistRead>> ReadAllAsync()
        {
            List<PlaylistRead> fromApi = new();
            Uri uri = new Uri(string.Format("http://localhost:8079/playlists", string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = JsonSerializer.Deserialize<List<PlaylistRead>>(content, serializer);
            }
            return fromApi;
        }

        public async Task<PlayListReadExtended> ReadAsync(int id)
        {
            PlayListReadExtended fromApi = new();
            Uri uri = new Uri(string.Format($"http://localhost:8079/playlists/{id}", string.Empty));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                fromApi = fromApi = JsonSerializer.Deserialize<PlayListReadExtended>(content, serializer);
            }

            return fromApi;
        }

        public void UpdateAsync(Playlist objeto)
        {
            throw new NotImplementedException();
        }

    }
}
