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

        StandingApi standingApi = new StandingApi();

        static List<Standing> standings = new List<Standing>();

        private readonly AppDBContext _context;
        public StandingApiController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          
            string defolt = "https://apiv2.apifootball.com?action=get_standings&league_id=148&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            List<Standing>  standings = await standingApi.GetListEntityAsync(defolt, client);
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
        
            standings = await standingApi.GetListEntityAsync(defolt, client);
            if (standings == null)
            {
                return NotFound();
            }
            return View(standings);
        }
        public async Task<IActionResult> SaveAllToDateBase(string id)
        {
            ViewData["Answer"] = "Збережено";
            int count = _context.Standings.Where(p => p.Competition_Id == id).Count();
            if (count != 0)
            {
                List<Standing> stan = standingApi.SaveAllToDateBase(_context, standings);
                if (stan.Count() == 0)
                {
                    ViewData["Answer"] = "Турнірна таблиця вже була збережена в базі даних";
                    return View(standings[0]);
                }
                foreach (Standing s in stan)
                {
                    _context.Standings.Add(s);
                }
                await _context.SaveChangesAsync();
                return View(standings[0]);
            }
            foreach (Standing s in standings)
            {
                _context.Standings.Add(s);
            }
            await _context.SaveChangesAsync();
            return View(standings[0]);    
        }
    }
}