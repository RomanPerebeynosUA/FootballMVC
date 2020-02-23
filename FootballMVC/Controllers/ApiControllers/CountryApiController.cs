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
    public class CountryApiController : Controller
    {
        private static HttpClient client = new HttpClient();

        CountryApi countryApi = new CountryApi();
        static List<Country> countries = new List<Country>();
        private readonly AppDBContext _context;

        public CountryApiController(AppDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            string defolt = "https://apiv2.apifootball.com?action=get_countries&APIkey=a31df99894dedace442c216f5e7bbb965d956ea8c88ba9b68fa2550b21583c24";
            countries = await countryApi.GetListEntityAsync(defolt, client);
            return View(countries);
        }
       
        public async Task<IActionResult> SaveToDateBase(string id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                foreach (Country c in countries)
                {
                    if (c.Id == id)
                    {
                        country = c;
                    }
                }
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                ViewData["Answer"] = "Збережено";
                return View();
            }
            ViewData["Answer"] = "Країна вже була збережена в базі даних";
            return View();
        }
        public async Task<IActionResult> SaveAllToDateBase()
        {
            ViewData["Answer"] = "Всі країни збережено в базі даних";
            List<Country> coun = new List<Country>();
            if (_context.Countries.Count() != 0)
            {
                coun = countryApi.SaveAllToDateBase(_context, countries);
                if (coun.Count() == 0)
                {
                    ViewData["Answer"] = "Всі країни вже були збережені в базі даних";
                    return View();
                }
                foreach (Country c in coun)
                {
                  _context.Countries.Add(c);
                }
                await _context.SaveChangesAsync();
                return View();
            }
            foreach (Country c in countries)
            {
                _context.Countries.Add(c);
            }
            await _context.SaveChangesAsync();
            return View();
        }
    }
}