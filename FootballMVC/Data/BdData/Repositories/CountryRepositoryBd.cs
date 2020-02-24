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
    public class CountryRepositoryBd : IRepositoryBd<Country, string>
    {
        AppDBContext _context;
        public CountryRepositoryBd(AppDBContext context)
        {
            _context = context;
        }
        public bool EntityExists(string id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        public async Task<Country> GetEntityItems(string id)
        {
            return await _context.Countries
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Country>> GetEntityListItems()
        {
            return await _context.Countries.ToListAsync();
        }

        public Task<List<Country>> GetEntityListItemsByKey()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country> GetEntityNoAsyncListItems()
        {
            return _context.Countries;
        }

        public async Task RemoveEntity(Country entity)
        {
            _context.Countries.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Country entity)
        {
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Country entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
