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
        public List<Standing> SaveAllToDateBase(AppDBContext _context, List<Standing> standings)
        {
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();
            List<string> str3 = new List<string>();

            List<Standing> standAdd = new List<Standing>();

            foreach (Standing t in standings)
            {
                str1.Add(t.Team_id);
            }
            foreach (Standing t in _context.Standings)
            {
                str2.Add(t.Team_id);
            }
            str3 = str1.Except(str2).ToList();

            foreach (Standing t in standings)
            {
                foreach (string s in str3)
                {
                    if (t.Team_id == s)
                    {
                        standAdd.Add(t);
                    }
                }
            }
            return (standAdd);
        }

    }

}
