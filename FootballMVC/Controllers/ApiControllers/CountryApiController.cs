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
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> SaveAllToDateBase()
        {
            List<Country> countryDb = new List<Country>();
            foreach (Country c in _context.Countries)
            {
                countryDb.Add(_context.Countries.FirstOrDefault());
            }
            int count = countryDb.Count();
            if (count !=0)
            {
                foreach (Country c in countryDb)
                {
                    foreach (Country t in countries)
                    {
                        if (c.Id != t.Id)
                        {
                            _context.Countries.Add(t);
                        }
                    }  
                }
                await _context.SaveChangesAsync();
                return View();
            }
            foreach (Country t in countries)
            {
               _context.Countries.Add(t);
            }
            await _context.SaveChangesAsync();
            return View();
        }
    }
}