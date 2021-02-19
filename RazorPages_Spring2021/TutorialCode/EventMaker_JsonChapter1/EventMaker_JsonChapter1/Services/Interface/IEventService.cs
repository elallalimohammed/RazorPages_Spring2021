using EventMaker_JsonChapter1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Services.Interface
{
   public  interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> GetEventAsync(int id);
        Task AddEventAsync(Event ev);
       Task  DeleteEventAsync(int id);
        Task UpdateEventAsync(Event ev);
       Task<List<Event>> FilterEventsByCityAsync(string city);
        Task<List<Event>> SearchEventsByCountryCodeAsync(string code);
    }
}
