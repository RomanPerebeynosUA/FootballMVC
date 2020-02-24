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
    public class CompetitionApiController : Controller
    {
        private  static HttpClient client = new HttpClient();

        static List<Competition> competitions = new List<Competition>();

        private readonly DataManager dataManager;
        public CompetitionApiController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_leagues&country_id=41&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            return View(await dataManager.CompetitionRepositoryApi.GetListEntityAsync(defolt, client));
        }

        public async Task<IActionResult> CountryLeags(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string defolt = "https://apiv2.apifootball.com?action=get_leagues&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24&country_id=";
            defolt += id;
            competitions = await dataManager.CompetitionRepositoryApi.GetListEntityAsync(defolt, client);
            return View(competitions);
        }
        public async Task<IActionResult> SaveToDateBase(string id)
        {
            var competition = dataManager.CompetitionRepositoryApi.GetEntityItemById(id);
            if (competition == null)
            {
                foreach (Competition c in competitions)
                {
                    if (c.Id == id)
                    {
                        competition = c;
                    }
                }
                await dataManager.CompetitionRepositoryApi.SaveEntity(competition);
                ViewData["Answer"] = "Збережено";
                return View(competition);
            }
            ViewData["Answer"] = "Турнір вже був збережений в базі даних";
            return View(competition);
        }
        public async Task<IActionResult> SaveAllToDateBase(string id)
        {
            List<Competition> coun = new List<Competition>();
            ViewData["Answer"] = "Збережено";
            if (dataManager.CompetitionRepositoryApi.GetEntityItems()
                .Where(p => p.CountryId == id).Count() != 0)
            {
                coun = dataManager.CompetitionRepositoryApi.SaveAllToDateBase(competitions);
                if(coun.Count == 0)
                {
                    ViewData["Answer"] = "Всі турніри даної країни, " +
                        "вже були збережені в базі даних";
                    return View(competitions[0]);
                }
                foreach (Competition c in coun)
                {
                    await dataManager.CompetitionRepositoryApi.SaveEntity(c);
                }
                return View(competitions[0]);
            }
            foreach (Competition c in competitions)
            {
                await dataManager.CompetitionRepositoryApi.SaveEntity(c);
            }
            return View(competitions[0]);
        }

    }
}