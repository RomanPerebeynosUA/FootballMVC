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
    public class CountryApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        CountryApi countryApi = new CountryApi();
        CompetitionApi competitionApi = new CompetitionApi();

        static List<Country> countries = new List<Country>();
        static List<Competition> competitions = new List<Competition>();


     
        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_countries&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            countries = await countryApi.GetListEntityAsync(defolt, client);
            return View(countries);
        }
        public async Task<IActionResult> CountryLeags(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_leagues&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&country_id=";
            defolt += id;
            competitions = await competitionApi.GetListEntityAsync(defolt, client);
            return View(competitions);
        }
    }
}