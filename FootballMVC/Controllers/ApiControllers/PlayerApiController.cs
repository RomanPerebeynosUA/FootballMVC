﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FootballMVC.Data.ApiData;
using FootballMVC.Data.ApiData.Repositories;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballMVC.Controllers.ApiControllers
{
    public class PlayerApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        PlayerApi playerApi = new PlayerApi();

        private readonly AppDBContext _context;
        public PlayerApiController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            string defolt = "https://apiv2.apifootball.com?action=get_players&player_id=3183500916&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            Player player = await playerApi.GetEntityAsync(defolt, client);
            List<Player> players = new List<Player>();
            players.Add(player);
           
            return View(players.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> SaveToDateBase(long Id)
        {
            string defolt = "https://apiv2.apifootball.com?action=get_players&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&player_id=";
            defolt += Id.ToString();
            Player player = await playerApi.GetEntityAsync(defolt, client);

                _context.Players.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }


    }
}