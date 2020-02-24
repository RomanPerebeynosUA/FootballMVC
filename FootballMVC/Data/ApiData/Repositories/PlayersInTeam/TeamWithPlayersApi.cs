using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities.PlayersInTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Repositories.PlayersInTeam
{
    public class TeamWithPlayersApi : IRepositoryApi<TeamWithPlayers, string>
    {
        public async Task<TeamWithPlayers> GetEntityAsync(string path, HttpClient client)
        {
            TeamWithPlayers team = null;
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // player = await response.Content.ReadAsAsync<Player>();
                json = await response.Content.ReadAsStringAsync();
                json = json.Trim('[', ']');
                team = JsonSerializer.Deserialize<TeamWithPlayers>(json);
            }
            return team;
        }

        public TeamWithPlayers GetEntityItemById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TeamWithPlayers> GetEntityItems()
        {
            throw new NotImplementedException();
        }

        public Task<List<TeamWithPlayers>> GetListEntityAsync(string path, HttpClient client)
        {
            throw new NotImplementedException();
        }
        public List<TeamWithPlayers> SaveAllToDateBase(List<TeamWithPlayers> elements)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(TeamWithPlayers entity)
        {
            throw new NotImplementedException();
        }
    }
}
