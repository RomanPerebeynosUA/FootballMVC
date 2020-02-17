using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FootballMVC.Data.ApiData;
using FootballMVC.Data.ApiData.Repositories;
using FootballMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballMVC.Controllers.ApiControllers
{
    public class PlayerController : Controller
    {
        private static HttpClient client = new HttpClient();

        PlayerApi playerApi = new PlayerApi();

        public async Task<IActionResult> Index()
        {
            Connection.ConnectionToApi(client);

            string defolt = "https://apiv2.apifootball.com/?action=get_players&player_id=3183500916&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            Player player = new Player();
            player = await playerApi.GetEntityAsync(defolt, client);
            // player.TeamId = 4;
            List<Player> players = new List<Player>();
            players.Add(player);
            return View(players.ToList());
        }
    }
}