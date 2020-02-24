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
    public class CompetitionRepositoryBd : IRepositoryBd<Competition, string>
    {
        AppDBContext _context;
        public CompetitionRepositoryBd(AppDBContext context)
        {
            _context = context;
        }
        public bool EntityExists(string id)
        {
            return _context.Competitions.Any(e => e.Id == id);
        }

        public async Task<Competition> GetEntityItems(string id)
        {
            return await _context.Competitions.Include(c => c.Country)
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Competition>> GetEntityListItemsByKey()
        {
            return await _context.Competitions.Include(c => c.Country).ToListAsync();
        }
        public async Task<List<Competition>> GetEntityListItems()
        {
            return await _context.Competitions.ToListAsync();
        }

        public async Task RemoveEntity(Competition entity)
        {
            _context.Competitions.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Competition entity)
        {
            _context.Competitions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Competition entity)
        {
            _context.Competitions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Competition> GetEntityNoAsyncListItems()
        {
            return _context.Competitions;
        }
    }
}
