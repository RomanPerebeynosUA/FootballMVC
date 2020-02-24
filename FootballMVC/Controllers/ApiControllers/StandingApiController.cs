using System;
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
    public class StandingApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        static List<Standing> standings = new List<Standing>();

        private readonly DataManager dataManager;
        public StandingApiController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
          
            string defolt = "https://apiv2.apifootball.com?action=get_standings&league_id=148&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            List<Standing>  standings = await dataManager.StandingRepositoryApi.GetListEntityAsync(defolt, client);
            return View(standings);
        }
        public async Task<IActionResult> ViewStandingByLeagID(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_standings&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&league_id=";
            defolt += id;
        
            standings = await dataManager.StandingRepositoryApi.GetListEntityAsync(defolt, client);
            if (standings == null)
            {
                return NotFound();
            }
            return View(standings);
        }
        public async Task<IActionResult> SaveAllToDateBase(string id)
        {
            ViewData["Answer"] = "Збережено";
            
            if (dataManager.StandingRepositoryApi.GetEntityItems().
                Where(p => p.Competition_Id == id).Count() != 0)
            {
                List<Standing> stan = dataManager.StandingRepositoryApi.SaveAllToDateBase(standings);
                if (stan.Count() == 0)
                {
                    ViewData["Answer"] = "Турнірна таблиця вже була збережена в базі даних";
                    return View(standings[0]);
                }
                foreach (Standing s in stan)
                {
                    await dataManager.StandingRepositoryApi.SaveEntity(s);
                }
                return View(standings[0]);
            }
            foreach (Standing s in standings)
            {
                await dataManager.StandingRepositoryApi.SaveEntity(s);
            }
            return View(standings[0]);    
        }
    }
}