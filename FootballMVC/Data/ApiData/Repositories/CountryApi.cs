using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Data.DataBase;
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
            List<Country> countries = new List<Country>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                countries = JsonSerializer.Deserialize<List<Country>>(json);
            }
            return countries;
        }
        public List<Country> SaveAllToDateBase(AppDBContext _context, List<Country> countries)
        {
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();

            List<Country> coun = new List<Country>(); 
                foreach (Country c in countries)
                {
                    str1.Add(c.Id);
                }
                foreach (Country c in _context.Countries)
                {
                    str2.Add(c.Id);
                }
            str1 = str1.Except(str2).ToList();

            if(str1.Count == 0)
            {
                return (coun);
            }
            foreach (Country c in countries)
            {
                foreach (string s in str1)
                {
                    if (c.Id == s)
                    {
                        coun.Add(c);
                    }
                }
            }
            return (coun);
        }
    }
}
