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
    public class StandingsController : Controller
    {
        private readonly DataManagerBd dataManager;
        public StandingsController(DataManagerBd dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataManager.StandingRepository.GetEntityListItems());
        }

        public async Task<IActionResult> Details(int id)
        {
           
            var standing = await dataManager.StandingRepository.GetEntityItems(id);
            if (standing == null)
            {
                return NotFound();
            }
            return View(standing);
        }

    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Team_Name,LeaguePosition,League_payed," +
            "League_W,League_D,League_L,League_PTS,Competition_Id,Team_id")] Standing standing)
        {
            if (ModelState.IsValid)
            {

                await dataManager.StandingRepository.SaveEntity(standing);
                return RedirectToAction(nameof(Index));
            }
            return View(standing);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var standing = await dataManager.StandingRepository.GetEntityItems(id);
            if (standing == null)
            {
                return NotFound();
            }
            return View(standing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Team_Name,LeaguePosition,League_payed,League_W,League_D,League_L,League_PTS,Competition_Id,Team_id")] Standing standing)
        {
            if (id != standing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await dataManager.StandingRepository.UpdateEntity(standing);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataManager.StandingRepository.EntityExists(standing.Id))
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
            return View(standing);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var standing = await dataManager.StandingRepository.GetEntityItems(id);
            if (standing == null)
            {
                return NotFound();
            }

            return View(standing);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standing = await  dataManager.StandingRepository.GetEntityItems(id);
            await dataManager.StandingRepository.RemoveEntity(standing);
            return RedirectToAction(nameof(Index));
        }
    }
}
