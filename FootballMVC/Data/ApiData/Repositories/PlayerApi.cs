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
    public class PlayerApi : IRepositoryApi<Player, long>
    {
        AppDBContext _context;
        public PlayerApi(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Player> GetEntityAsync(string path, HttpClient client)
        {
            Player player = null;
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
               
                json = await response.Content.ReadAsStringAsync();
                json = json.Trim('[', ']');
                player = JsonSerializer.Deserialize<Player>(json);
            }
            return player;
        }

        public Task<List<Player>> GetListEntityAsync(string path, HttpClient client)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Player> GetEntityItems()
        {
            return _context.Players;
        }

        public  List<Player> SaveAllToDateBase( List<Player> players)
        {
            List<long> str1 = new List<long>();
            List<long> str2 = new List<long>();
            List<Player> play = new List<Player>();

            foreach (Player t in players)
            {
                str1.Add(t.Id);
            }
            foreach (Player t in _context.Players.Where(p => p.TeamId == players[0].TeamId))
            {
                    str2.Add(t.Id);
            }
            str1 = str1.Except(str2).ToList();

            foreach (Player t in players)
            {
                foreach (long s in str1)
                {
                    if (t.Id == s)
                    {
                        play.Add(t);
                    }
                }
            }
            return (play);
        }
        public Player GetEntityItemById(long id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public async Task SaveEntity(Player entity)
        {
            _context.Players.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}

