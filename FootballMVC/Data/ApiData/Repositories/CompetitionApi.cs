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
                  json = await response.Content.ReadAsStringAsync();
                 competitions = JsonSerializer.Deserialize<List<Competition>>(json);
            }
            return competitions;
        }
        public List<Competition> SaveAllToDateBase(AppDBContext _context, List<Competition> competitions)
        {
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();
            List<Competition> coun = new List<Competition>();
            foreach (Competition c in competitions)
            {
                str1.Add(c.Id);
            }
            foreach (Competition c in _context.Competitions.Where(
                p => p.CountryId == competitions[0].CountryId))
            {
                str2.Add(c.Id);
            }
            str1 = str1.Except(str2).ToList();
            if (str1.Count == 0)
            {
                return (coun);
            }
            foreach (Competition c in competitions)
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
