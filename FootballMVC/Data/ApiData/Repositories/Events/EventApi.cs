using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData.Repositories.Events
{
    public class EventApi : IRepositoryApi<Event, string>
    {
        AppDBContext _context;
        public EventApi(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEntityAsync(string path, HttpClient client)
        {
            Event country = null;
            List<Event> countries = new List<Event>();
            string json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                countries = JsonSerializer.Deserialize<List<Event>>(json);
              //  country = countries.FirstOrDefault(p => p.Id == "43");
            }
            return country;
        }

        public Event GetEntityItemById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Event> GetEntityItems()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Event>> GetListEntityAsync(string path, HttpClient client)
        {
            string json;
          
            List<Event> events = new List<Event>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
              
                events = JsonSerializer.Deserialize<List<Event>>(json);
                
            }
            return events;
        }

        public List<Event> SaveAllToDateBase(List<Event> elements)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
