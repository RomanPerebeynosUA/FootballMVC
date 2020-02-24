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
    public class PlayersController : Controller
    {
        private readonly DataManagerBd dataManager;
        public PlayersController(DataManagerBd dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataManager.PlayerRepository.GetEntityListItemsByKey());
        }

        public async Task<IActionResult> Details(long id)
        {
            var player = await dataManager.PlayerRepository.GetEntityItems(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(dataManager.TeamRepository.GetEntityNoAsyncListItems(), "Id", "Id");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Number,Country,Type,Age," +
            "Match_played,Goals,Yellow_cards,Red_cards,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                await dataManager.PlayerRepository.SaveEntity(player);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(dataManager.TeamRepository.GetEntityNoAsyncListItems(), "Id", "Id", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
         
            var player = await dataManager.PlayerRepository.GetEntityItems(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList (dataManager.TeamRepository.GetEntityNoAsyncListItems(), "Id", "Id", player.TeamId);
            return View(player);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Number,Country,Type,Age," +
            "Match_played,Goals,Yellow_cards,Red_cards,TeamId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await dataManager.PlayerRepository.UpdateEntity(player);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataManager.PlayerRepository.EntityExists(player.Id))
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
            ViewData["TeamId"] = new SelectList(dataManager.TeamRepository.GetEntityNoAsyncListItems(), "Id", "Id", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var player = await dataManager.PlayerRepository.GetEntityItems(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var player = await dataManager.PlayerRepository.GetEntityItems(id);
            await  dataManager.PlayerRepository.RemoveEntity(player);
            return RedirectToAction(nameof(Index));
        }
    }
}
