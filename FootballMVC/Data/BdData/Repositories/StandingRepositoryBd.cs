using FootballMVC.Data.BdData.Interfaces;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Data.BdData.Repositories
{
    public class StandingRepositoryBd : IRepositoryBd<Standing, int>
    {
        AppDBContext _context;
        public StandingRepositoryBd(AppDBContext context)
        {
            _context = context;
        }

        public bool EntityExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }

        public async Task<Standing> GetEntityItems(int id)
        {
            return await _context.Standings
                   .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Standing>> GetEntityListItems()
        {
            return await _context.Standings.ToListAsync();
        }

        public Task<List<Standing>> GetEntityListItemsByKey()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Standing> GetEntityNoAsyncListItems()
        {
            return _context.Standings;
        }

        public async Task RemoveEntity(Standing entity)
        {
            _context.Standings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Standing entity)
        {
            _context.Standings.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Standing entity)
        {
            _context.Standings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
