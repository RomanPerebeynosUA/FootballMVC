using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities.Events;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballMVC.Controllers.ApiControllers
{
    public class EventApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        static List<Event> events  = new List<Event>();

        private readonly DataManager dataManager;
        public EventApiController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com/?action=get_events&from=2020-11-27&to=2020-11-29&APIkey=557a4c8dd12d182ad230f3683aecd88058a44d6487da02cb5516a1f57114b1c4&league_id=149";
            return View(await dataManager.EventApi.GetListEntityAsync(defolt, client));
        }

    }
}
