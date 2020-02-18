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
    public class CompetitionApi : IRepositoryApi<Competition>
    {
        public  async Task<Competition> GetEntityAsync(string path, HttpClient client)
        {
            throw new NotImplementedException();
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
