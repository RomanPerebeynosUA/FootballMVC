using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;

namespace FootballMVC.Controllers.DataControllers
{
    public class CompetitionsController : Controller
    {
        private readonly DataManagerBd dataManager;
        public CompetitionsController(DataManagerBd dataManager)
        {
            this.dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dataManager.CompetitionRepository.GetEntityListItemsByKey());
        }

   
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await dataManager.
                CompetitionRepository.GetEntityItems(id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

    
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList( dataManager.
                CountryRepository.GetEntityNoAsyncListItems(), "Id", "Id");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                await dataManager.
                CompetitionRepository.SaveEntity(competition);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(dataManager.
                CountryRepository.GetEntityNoAsyncListItems(), "Id", "Id", competition.CountryId);
            return View(competition);
        }

    
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await dataManager.
                CompetitionRepository.GetEntityItems(id);
            if (competition == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(dataManager.
                CountryRepository.GetEntityNoAsyncListItems(), "Id", "Id", competition.CountryId);
            return View(competition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,CountryId")] Competition competition)
        {
            if (id != competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await dataManager.
                  CompetitionRepository.UpdateEntity(competition);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataManager.
                  CompetitionRepository.EntityExists(competition.Id))
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
            ViewData["CountryId"] = new SelectList(dataManager.
                CountryRepository.GetEntityNoAsyncListItems(), "Id", "Id", competition.CountryId);
            return View(competition);
        }

    
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await dataManager.
                CompetitionRepository.GetEntityItems(id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var competition = await dataManager.
                CompetitionRepository.GetEntityItems(id);
           
            await dataManager.
                CompetitionRepository.RemoveEntity(competition);
            return RedirectToAction(nameof(Index));
        }
    }
}
