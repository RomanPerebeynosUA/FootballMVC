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
    public class PlayerRepositoryBd : IRepositoryBd<Player, long>
    {
        AppDBContext _context;
        public PlayerRepositoryBd(AppDBContext context)
        {
            _context = context;
        }
        public bool EntityExists(long id)
        {
            return _context.Players.Any(e => e.Id == id);
        }

        public async Task<Player> GetEntityItems(long id)
        {
            return await _context.Players.Include(p => p.Team)
                  .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Player>> GetEntityListItems()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<List<Player>> GetEntityListItemsByKey()
        {
            return await _context.Players.Include(c => c.Team).ToListAsync();
        }

        public IQueryable<Player> GetEntityNoAsyncListItems()
        {
            return _context.Players;
        }
        public async Task RemoveEntity(Player entity)
        {
            _context.Players.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Player entity)
        {
            _context.Players.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Player entity)
        {
            _context.Players.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
