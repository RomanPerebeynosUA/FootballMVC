using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Repositories
{
    public class TeamApi : IRepositoryApi<Team>
    {
        public async Task<Team> GetEntityAsync(string path, HttpClient client)
        {
            Team team = null;
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
                 if (response.IsSuccessStatusCode)
            {
                // player = await response.Content.ReadAsAsync<Player>();
                json = await response.Content.ReadAsStringAsync();
                json = json.Trim('[', ']');
                team = JsonSerializer.Deserialize<Team>(json);
            }
            return team;
        }


        public async Task<List<Team>> GetListEntityAsync(string path, HttpClient client)
        {
            string json;
            List<Team> tems = new List<Team>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                tems = JsonSerializer.Deserialize<List<Team>>(json);
            }
            return tems;
        }
    }
}
