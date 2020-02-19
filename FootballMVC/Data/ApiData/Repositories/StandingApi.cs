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
    public class StandingApi : IRepositoryApi<Standing>
    {
        public Task<Standing> GetEntityAsync(string path, HttpClient client)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Standing>> GetListEntityAsync(string path, HttpClient client)
        {
            string json;
            List<Standing> standings = new List<Standing>();
           
            string eror = "{\"error\":404,\"message\":\"Standing not found!\"}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // competitions = await response.Content.ReadAsAsync < List<Competition>>();
                json = await response.Content.ReadAsStringAsync();
                if (json == eror) 
                {
                    standings = null;
                    return standings;
                }
                standings = JsonSerializer.Deserialize<List<Standing>>(json);
            }
            return standings;
        }

    }

}
