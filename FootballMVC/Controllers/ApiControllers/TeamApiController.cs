﻿using System;
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

        TeamApi teamApi = new TeamApi();
        TeamWithPlayersApi teamwithPlayersApi = new TeamWithPlayersApi();
        static string competitionID;
       

        private readonly AppDBContext _context;

        public TeamApiController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_teams&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&team_id=2611";
            List<Team> teams = new List<Team>();
            teams.Add(await teamApi.GetEntityAsync(defolt, client));
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
            teams = await teamApi.GetListEntityAsync(defolt, client);
            return View(teams.ToList());
        }
        public async Task<IActionResult> SaveToDateBase(string id)
        {
            var team = await _context.Teams.FindAsync(id);
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
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
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
            teamAdd = teamApi.SaveAllToDateBase(_context, teams);
            if(teamAdd.Count() == 0)
            {
                ViewData["Answer"] = "Команда вже була збережена в базі даних";
                return View();
            }
            foreach (Team t in teamAdd)
            {
              _context.Teams.Add(t);
            }
             await _context.SaveChangesAsync();
            return View();
        }
    }
}