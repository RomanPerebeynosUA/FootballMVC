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
    public class TeamsController : Controller
    {
        private readonly DataManagerBd dataManager;
        public TeamsController(DataManagerBd dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataManager.TeamRepository.GetEntityListItems());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await dataManager.TeamRepository.GetEntityItems(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

     
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                await dataManager.TeamRepository.SaveEntity(team);
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await dataManager.TeamRepository.GetEntityItems(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await dataManager.TeamRepository.UpdateEntity(team);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataManager.TeamRepository.EntityExists(team.Id))
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
            return View(team);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await dataManager.TeamRepository.GetEntityItems(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var team = await dataManager.TeamRepository.GetEntityItems(id);

            await dataManager.TeamRepository.RemoveEntity(team);
            return RedirectToAction(nameof(Index));
        }
    }
}
