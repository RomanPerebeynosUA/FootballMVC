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
    public class CountryApi : IRepositoryApi<Country>
    {
        public async Task<Country> GetEntityAsync(string path, HttpClient client)
        {
            Country country = null;
            List<Country> countries = new List<Country>();
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                countries = JsonSerializer.Deserialize<List<Country>>(json);
                country = countries.FirstOrDefault(p => p.Id == "43");
            }
            return country;
        }
        public async Task<List<Country>> GetListEntityAsync(string path, HttpClient client)
        {
            string json;
            client.BaseAddress = new Uri("https://apiv2.apifootball.com");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<Country> countries = new List<Country>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                countries = JsonSerializer.Deserialize<List<Country>>(json);
            }
            return countries;
        }
    }
  
}
