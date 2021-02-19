using EventMaker_EFChapter2.Helpers.EventHelpers;
using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Services.Interface
{
    public class JsonEventRepository : IEventService
    {
        string JsonFileName = @"C:\Users\EASJ\Documents\DeskTop\ASP.NET RAZOR PAGES\For_Final_Project\ORIGINALS\RazorPagesEventMaker\wwwroot\Data\JsonCountryEvents.json";

        public List<Event> GetAllEvents()
        {
            List<Event> returnList = JsonFileReader.ReadJson(JsonFileName);
            return returnList;
        }
        public void AddEvent(Event evt)
        {
            List<Event> @events = GetAllEvents().ToList();
            List<int> eventIds = new List<int>();
            foreach (var ev in events)
            {
                eventIds.Add(ev.Id);
            }
            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                evt.Id = start + 1;
            }
            else
            {
                evt.Id = 1;
            }
            events.Add(evt);
            JsonFileWritter.WriteToJson(@events, JsonFileName);

        }

        public void DeleteEvent(int id)
        {
            List<Event> @events = GetAllEvents().ToList();

            foreach (var e in @events)
            {
                if (e.Id == id)
                {
                    @events.Remove(e);
                    break;
                }
            }
            JsonFileWritter.WriteToJson(@events, JsonFileName);
        }
        public Event GetEvent(int id)
        {
            foreach (var v in GetAllEvents())
            {
                if (v.Id == id)
                    return v;
            }
            return new Event();
        }

        public void UpdateEvent(Event @evt)
        {
            List<Event> @events = GetAllEvents().ToList();

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
            JsonFileWritter.WriteToJson(@events, JsonFileName);
        }

        public List<Event> FilterEventsByCity(string city)
        {
            List<Event> filteredList = new List<Event>();

            foreach (var ev in GetAllEvents().ToList())
            {
                if (ev.City.Contains(city))
                {
                    filteredList.Add(ev);
                }
            }
            return filteredList;
        }

        public List<Event> SearchEventsByCountryCode(string code)
        {
            List<Event> filteredList = new List<Event>();

            foreach (var ev in GetAllEvents().ToList())
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
