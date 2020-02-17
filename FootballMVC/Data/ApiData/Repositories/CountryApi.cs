﻿using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Repositories
{
    public class CountryApi : IRepositoryApi<Country>
    {
        public async Task<Country> GetEntityAsync(string path, HttpClient client)
        {
            Country country = null;
            string json;
            List<Country> countries = new List<Country>();
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
