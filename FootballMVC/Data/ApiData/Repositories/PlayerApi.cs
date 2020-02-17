using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Repositories
{
    public class PlayerApi : IRepositoryApi<Player>
    {
        public async Task<Player> GetEntityAsync(string path, HttpClient client)
        {
            Player player = null;
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // player = await response.Content.ReadAsAsync<Player>();
                json = await response.Content.ReadAsStringAsync();
                json = json.Trim('[', ']');
                player = JsonSerializer.Deserialize<Player>(json);
            }
            return player;
        }
    }
}
