using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FootballMVC.Data.ApiData;
using FootballMVC.Data.ApiData.Repositories;
using FootballMVC.Data.ApiData.Repositories.PlayersInTeam;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballMVC.Controllers.ApiControllers
{
    public class TeamApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        static List<Player> players = new List<Player>();
        static List<Team> teams = new List<Team>();
        static string competitionID;
        private readonly DataManager dataManager;
        public TeamApiController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Team> teamsforone = new List<Team>();
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&team_id=2611";
            teamsforone.Add(await dataManager.TeamRepositoryApi.GetEntityAsync(defolt, client));
            return View(teams.ToList());
        }
        public async Task<IActionResult> ViewTemsByLeagID(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            competitionID = id;
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&league_id=";
            defolt += id;
            ViewBag.Id = id;
            teams = await dataManager.TeamRepositoryApi.GetListEntityAsync(defolt, client);
            return View(teams.ToList());
        }
        public async Task<IActionResult> SaveToDateBase(string id)
        {
            var team = dataManager.TeamRepositoryApi.GetEntityItemById(id);
            ViewBag.Id = competitionID;
            if (team == null)
            {
                foreach (Team c in teams)
                {
                    if (c.Id == id)
                    {
                        team = c;
                    }
                }
                await dataManager.TeamRepositoryApi.SaveEntity(team);
                ViewData["Answer"] = "Збережено";
                return View(team);
            }
            ViewData["Answer"] = "Команда вже була збережена в базі даних";
            return View(team);
        }
        public async Task<IActionResult> SaveAllToDateBase()
        {
            List<Team> teamAdd;
            ViewData["Answer"] = "Збережено";
            ViewBag.Id = competitionID;
            teamAdd = dataManager.TeamRepositoryApi.SaveAllToDateBase(teams);
            if(teamAdd.Count() == 0)
            {
                ViewData["Answer"] = "Команда вже була збережена в базі даних";
                return View();
            }
            foreach (Team t in teamAdd)
            {
                await dataManager.TeamRepositoryApi.SaveEntity(t);
            }
            return View();
        }
    }
}