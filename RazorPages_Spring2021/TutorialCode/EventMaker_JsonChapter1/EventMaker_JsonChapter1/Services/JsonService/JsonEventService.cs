using EventMaker_JsonChapter1.Models;
using EventMaker_JsonChapter1.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Services.JsonService
{
    public class JsonEventService: IEventService
    {
        private List<Event> events;
        private JsonFileService<Event> jsonService { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Events.json"); }
        }
        public JsonEventService(JsonFileService<Event> jsonFileCustomerService,
                                       IWebHostEnvironment webHostEnvironment)
        {
            jsonService = jsonFileCustomerService;
            WebHostEnvironment = webHostEnvironment;
            jsonService.FileName = JsonFileName;
            @events = jsonService.LoadAsync().Result;
        }
    
        public async Task  AddEventAsync(Event evt)
        {
            evt.Id = GetId();            
            @events.Add(evt);
           await  jsonService.SaveAsync(@events);
        }

        private int GetId()
        {
            List<int> eventIds = new List<int>();
            foreach (var ev in @events)
            {
                eventIds.Add(ev.Id);
            }
            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                return  start + 1;
            }
            else
            {
                return 1;
            }
        }

        public async Task DeleteEventAsync(int id)
        {
           foreach (var e in @events)
            {
                if (e.Id == id)
                {
                    @events.Remove(e);
                    break;
                }
            }
           await jsonService.SaveAsync(@events);
        }
        public async Task<Event> GetEventAsync(int id)
        {
           foreach (var v in @events)
            {
                if (v.Id == id)
                    return v;
            }
            return new Event();
        }

         public async Task UpdateEventAsync(Event @evt)
        {
            if (@evt != null)
            {
                foreach (var e in @events)
                {
                    if (e.Id == @evt.Id)
                    {
                        e.Id = evt.Id;
                        e.Name = evt.Name;
                        e.City = evt.City;
                        e.Description = evt.Description;
                        e.DateTime = evt.DateTime;
                        e.CountryCode = evt.CountryCode;
                    }
                }
            }
           await  jsonService.SaveAsync(@events);
        }
        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await jsonService.LoadAsync();
        }
        public async Task<List<Event>> FilterEventsByCityAsync(string city)
        {
            List<Event> @events = await jsonService.LoadAsync();
            List<Event> filteredList = new List<Event>();
          foreach (var ev in  @events)
            {
                if (ev.City.Contains(city))
                {
                    filteredList.Add(ev);
                }
            }
            return filteredList;
        }

        public async Task<List<Event>> SearchEventsByCountryCodeAsync(string code)
        {
            List<Event> @events =await  jsonService.LoadAsync();
            List<Event> filteredList = new List<Event>();
            foreach (var ev in @events)
            {
                if (ev.CountryCode == code)
                {
                    filteredList.Add(ev);
                }
            }
            return filteredList;
        }
    }
}
