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
    public class CompetitionApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        CompetitionApi competitionApi = new CompetitionApi();

        static List<Competition> competitions = new List<Competition>();

        public async Task<IActionResult> Index()
        {
            Connection.ConnectionToApi(client);
            string defolt = "?action=get_leagues&country_id=41&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            competitions = await competitionApi.GetListEntityAsync(defolt, client);
            return View(competitions);
        }

        //public async Task<IActionResult> ViewTeamsOfCompetition()
        //{
        //    Connection.ConnectionToApi(client);
        //    string defolt = "?action=get_leagues&country_id=41&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
        //    competitions = await competitionApi.GetListEntityAsync(defolt, client);
        //    return View(competitions);
        //}
    }
}