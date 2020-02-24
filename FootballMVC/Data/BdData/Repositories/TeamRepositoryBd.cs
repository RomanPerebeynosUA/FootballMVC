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
    public class TeamRepositoryBd : IRepositoryBd<Team, string>
    {
        AppDBContext _context;
        public TeamRepositoryBd(AppDBContext context)
        {
            _context = context;
        }
        public bool EntityExists(string id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        public async Task<Team> GetEntityItems(string id)
        {
            return await _context.Teams
                  .FirstOrDefaultAsync(m => m.Id == id);
         
        }

        public async Task<List<Team>> GetEntityListItems()
        {
            return await _context.Teams.ToListAsync();

        }

        public Task<List<Team>> GetEntityListItemsByKey()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Team> GetEntityNoAsyncListItems()
        {
            return _context.Teams;
        }

        public async Task RemoveEntity(Team entity)
        {
            _context.Teams.Remove(entity);
            await _context.SaveChangesAsync();
        
        }

        public async Task SaveEntity(Team entity)
        {
            _context.Teams.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Team entity)
        {
            _context.Teams.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
