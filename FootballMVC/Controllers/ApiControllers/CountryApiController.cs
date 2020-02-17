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

        public async Task<IActionResult> Index()
        {
            Connection.ConnectionToApi(client);
            string defolt = "?action=get_countries&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            return View(await countryApi.GetListEntityAsync(defolt, client));
        }
        //public async Task<IActionResult> Index()
        //{
        //    Connection.ConnectionToApi(client);

        //    string defolt = "?action=get_countries&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
        //    Country country = new Country();
        //    List<Country> countrys = new List<Country>();
        //    countrys = await countryApi.GetEntityAsync(defolt, client);
        //    countrys.Add(country);
        //    return View(countrys.ToList());
        //}
    }
}