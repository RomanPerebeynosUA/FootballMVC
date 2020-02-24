using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Data.BdData.Interfaces
{
    public interface IRepositoryBd<T,K>
    {
        bool EntityExists(K id);
        Task<List<T>> GetEntityListItems();
        Task<List<T>> GetEntityListItemsByKey();
        Task<T> GetEntityItems(K id);
        Task SaveEntity(T entity);
        Task RemoveEntity(T entity);
        Task UpdateEntity(T entity);
        IQueryable<T> GetEntityNoAsyncListItems();
    }
}
