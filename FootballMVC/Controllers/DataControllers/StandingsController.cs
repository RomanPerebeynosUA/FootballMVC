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
        private readonly AppDBContext _context;

        public StandingsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Standings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Standings.ToListAsync());
        }

        // GET: Standings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standing = await _context.Standings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standing == null)
            {
                return NotFound();
            }

            return View(standing);
        }

        // GET: Standings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Standings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Team_Name,LeaguePosition,League_payed,League_W,League_D,League_L,League_PTS,Competition_Id,Team_id")] Standing standing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standing);
        }

        // GET: Standings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standing = await _context.Standings.FindAsync(id);
            if (standing == null)
            {
                return NotFound();
            }
            return View(standing);
        }

        // POST: Standings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(standing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandingExists(standing.Id))
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

        // GET: Standings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standing = await _context.Standings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standing == null)
            {
                return NotFound();
            }

            return View(standing);
        }

        // POST: Standings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standing = await _context.Standings.FindAsync(id);
            _context.Standings.Remove(standing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandingExists(int id)
        {
            return _context.Standings.Any(e => e.Id == id);
        }
    }
}
