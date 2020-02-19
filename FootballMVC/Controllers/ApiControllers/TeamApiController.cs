using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FootballMVC.Data.ApiData.Repositories;
using FootballMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballMVC.Controllers.ApiControllers
{
    public class TeamApiController : Controller
    {
        private static HttpClient client = new HttpClient();
        static List<Player> players = new List<Player>();

        TeamApi teamApi = new TeamApi();
        StandingApi StandingApi = new StandingApi();

        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&team_id=2611";
            Team team = new Team();
            team = await teamApi.GetEntityAsync(defolt, client);
            List<Team> teams = new List<Team>();
            teams.Add(team);
            return View(teams.ToList());
        }
        public async Task<IActionResult> ViewTemsByLeagID(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&league_id=";
            defolt += id;
            List<Team> teams = new List<Team>();
            teams = await teamApi.GetListEntityAsync(defolt, client);

            return View(teams.ToList());
        }
        public async Task<IActionResult> ViewPlayersByTeamId(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team team = new Team();
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&team_id=";
            defolt += id;
            team = await teamApi.GetEntityAsync(defolt, client);
            foreach (Player p in team.Players)
            {    
                p.TeamId = team.Id;
                players.Add(p);
            }
            return View(team.Players.ToList());
        }
        public async Task<IActionResult> ViewStandingByLeagID(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_standings&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&league_id=";
            defolt += id;
            List<Standing> standings = new List<Standing>();
            standings = await StandingApi.GetListEntityAsync(defolt, client);
            if (standings == null)
            {
                return NotFound();
            }
            return View(standings);
        }
    }
}