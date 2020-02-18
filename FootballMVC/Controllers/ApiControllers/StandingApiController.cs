﻿using System;
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
    public class StandingApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        StandingApi standingApi = new StandingApi();

        static List<Standing> standings = new List<Standing>();

        public async Task<IActionResult> Index()
        {
            Connection.ConnectionToApi(client);
            string defolt = "?action=get_standings&league_id=148&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            standings = await standingApi.GetListEntityAsync(defolt, client);
            return View(standings);
        }

    }
}