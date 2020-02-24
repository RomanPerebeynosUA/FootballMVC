using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Data.ApiData.Repositories.PlayersInTeam;
using FootballMVC.Models.Entities;
using FootballMVC.Models.Entities.PlayersInTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Data.DataBase
{
    public class DataManager
    {
        public IRepositoryApi<Country, string> CountryRepositoryApi { get; set; }
        public IRepositoryApi<Competition, string> CompetitionRepositoryApi { get; set; }
        public IRepositoryApi<Standing, int> StandingRepositoryApi { get; set; }
        public IRepositoryApi<Player, long> PlayerRepositoryApi { get; set; }
        public IRepositoryApi<Team, string> TeamRepositoryApi { get; set; }
        public IRepositoryApi<TeamWithPlayers, string> TeamWithPRepositoryApi { get; set; }


        public DataManager(IRepositoryApi<Country, string> countryRepositoryApi, IRepositoryApi<Competition, string> competitionRepositoryApi,
            IRepositoryApi<Standing, int> standingRepositoryApi, IRepositoryApi<Player, long>  playerRepositoryApi,
             IRepositoryApi<Team, string> teamRepositoryApi, IRepositoryApi<TeamWithPlayers, string> teamWithPRepositoryApi)
        {
            CountryRepositoryApi = countryRepositoryApi;
            CompetitionRepositoryApi = competitionRepositoryApi;
            StandingRepositoryApi = standingRepositoryApi;
            PlayerRepositoryApi = playerRepositoryApi;
            TeamRepositoryApi = teamRepositoryApi;
            TeamWithPRepositoryApi = teamWithPRepositoryApi;
        }

    }
}
