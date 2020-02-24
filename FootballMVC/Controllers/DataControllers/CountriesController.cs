using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;
using FootballMVC.Data.ApiData.Interfaces;

namespace FootballMVC.Controllers.DataControllers
{
    public class CountriesController : Controller
    {

        private readonly DataManagerBd dataManager;
        public CountriesController(DataManagerBd dataManager)
        {
            this.dataManager = dataManager;
        }

      
        public async Task<IActionResult> Index()
        {

            return View(await dataManager.CountryRepository.GetEntityListItems());
        }

        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await dataManager.CountryRepository.GetEntityItems(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

     
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {

                await dataManager.CountryRepository.SaveEntity(country);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

       
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await dataManager.CountryRepository.GetEntityItems(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await dataManager.CountryRepository.UpdateEntity(country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataManager.CountryRepository.EntityExists(country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

     
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await dataManager.CountryRepository.GetEntityItems(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var country = await dataManager.CountryRepository.GetEntityItems(id);

            await dataManager.CountryRepository.RemoveEntity(country);
            return RedirectToAction(nameof(Index));
        }
    }
}
