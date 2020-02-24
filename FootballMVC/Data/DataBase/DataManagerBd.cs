using FootballMVC.Data.BdData.Interfaces;
using FootballMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Data.DataBase
{
    public class DataManagerBd
    {
        public IRepositoryBd<Country, string> CountryRepository { get; set; }
        public IRepositoryBd<Competition, string> CompetitionRepository { get; set; }
        public IRepositoryBd<Standing, int> StandingRepository { get; set; }
        public IRepositoryBd<Player, long> PlayerRepository { get; set; }
        public IRepositoryBd<Team, string> TeamRepository { get; set; }
    


        public DataManagerBd(IRepositoryBd<Country, string> countryRepository, IRepositoryBd<Competition, string> competitionRepository,
            IRepositoryBd<Standing, int> standingRepository, IRepositoryBd<Player, long> playerRepository,
             IRepositoryBd<Team, string> teamRepository)
        {
            CountryRepository = countryRepository;
            CompetitionRepository = competitionRepository;
            StandingRepository = standingRepository;
            PlayerRepository = playerRepository;
            TeamRepository = teamRepository;
         
        }
    }
}
