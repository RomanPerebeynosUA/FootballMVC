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
        private static HttpClient client = new HttpClient();

        private CompetitionApi competitionApi = new CompetitionApi();

        static List<Competition> competitions = new List<Competition>();

        private readonly AppDBContext _context;

        public CompetitionApiController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_leagues&country_id=41&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            return View(await competitionApi.GetListEntityAsync(defolt, client));
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
        public async Task<IActionResult> SaveToDateBase(string id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                foreach (Competition c in competitions)
                {
                    if (c.Id == id)
                    {
                        competition = c;
                    }
                }

                _context.Competitions.Add(competition);
                await _context.SaveChangesAsync();
                competition = null;
                return View(competition);
            }
            return View(competition);
        }
        public async Task<IActionResult> SaveAllToDateBase(string id)
        {
            List<Competition> coun = new List<Competition>();
            bool saved = false;
            int count = _context.Competitions.Where(p => p.CountryId == id).Count();
            if (count != 0)
            {
                coun = competitionApi.SaveAllToDateBase(_context, competitions);
                foreach (Competition c in coun)
                {
                    _context.Competitions.Add(c);
                }
                await _context.SaveChangesAsync();
                saved = true;
                return View();
            }
            foreach (Competition c in competitions)
            {
                _context.Competitions.Add(c);
            }
            await _context.SaveChangesAsync();
          
            return View(saved);
        }

    }
}