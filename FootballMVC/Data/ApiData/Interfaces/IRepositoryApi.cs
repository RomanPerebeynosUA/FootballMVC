using FootballMVC.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Interfaces
{
   
        public interface IRepositoryApi<T,K> 
        {
            Task<T> GetEntityAsync(string path, HttpClient client);
            Task<List<T>> GetListEntityAsync(string path, HttpClient client);
            List<T> SaveAllToDateBase(List<T> elements);
            IQueryable<T> GetEntityItems();
            T GetEntityItemById(K id);
            Task SaveEntity(T entity);
            

    }
    
}
