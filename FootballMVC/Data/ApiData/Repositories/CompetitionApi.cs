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
    public class CompetitionApi : IRepositoryApi<Competition>
    {
        public  async Task<Competition> GetEntityAsync(string path, HttpClient client)
        {
            Competition competition = null;
            List<Competition> competitions = new List<Competition>();
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                competitions = JsonSerializer.Deserialize<List<Competition>>(json);
                competition = competitions.FirstOrDefault(p => p.Id == "43");
            }
            return competition;
        }

        public async Task<List<Competition>> GetListEntityAsync(string path, HttpClient client)
        {
            string json;
            List<Competition> competitions = new List<Competition>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
               // competitions = await response.Content.ReadAsAsync < List<Competition>>();
                  json = await response.Content.ReadAsStringAsync();
                 competitions = JsonSerializer.Deserialize<List<Competition>>(json);
            }
            return competitions;
        }
    }
}
