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
using FootballMVC.Models.Entities.PlayersInTeam;
using Microsoft.AspNetCore.Mvc;

namespace FootballMVC.Controllers.ApiControllers
{
    public class PlayerApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        static List<Player> players = new List<Player>();
        static string TeamId;

        private readonly DataManager dataManager;
        public PlayerApiController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_players&player_id=3183500916&APIkey=345ebb1d5cb902a9de9280564d2c2467de4d55af83f5ee1b7b25c4591ebb078e";
            return View(await dataManager.PlayerRepositoryApi.GetEntityAsync(defolt, client));
        }

        public async Task<IActionResult> ViewPlayersByTeamId(string id)
        {
            TeamId = id;
            ViewBag.Id = TeamId;
            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=345ebb1d5cb902a9de9280564d2c2467de4d55af83f5ee1b7b25c4591ebb078e&team_id=";
            defolt += id;
            TeamWithPlayers team = await dataManager.TeamWithPRepositoryApi.GetEntityAsync(defolt, client);
            foreach (Player p in team.Players)
            {
                p.TeamId = team.Id;
                players.Add(p);
            }
            return View(team.Players.ToList());
        }
        public async Task<IActionResult> SaveAllToDateBase()
        {
            ViewBag.Id = TeamId;
            ViewData["Answer"] = "Збережено";
            List<Player> play = dataManager.PlayerRepositoryApi.SaveAllToDateBase(players);
            if (play.Count() == 0)
            {
                ViewData["Answer"] = "Гравці вже були збережені в базі даних";
                return View();
            }
            foreach (Player p in play)
            {
                await dataManager.PlayerRepositoryApi.SaveEntity(p);
            }
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> SaveToDateBase(long Id)
        //{
        //    string defolt = "https://apiv2.apifootball.com?action=get_players&APIkey=345ebb1d5cb902a9de9280564d2c2467de4d55af83f5ee1b7b25c4591ebb078e&player_id=";
        //    defolt += Id.ToString();
        //    Player player = await playerApi.GetEntityAsync(defolt, client);

        //        _context.Players.Add(player);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //}


    }
}