using EventMaker_EFChapter2.Models;
using EventMaker_EFChapter2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Services.DBFService
{
    public class EventService:IEventService
    {
        private EventMakerDBContext _context;
       public EventService(EventMakerDBContext context)
        {
            _context = context;
        }    
        public void AddEvent(Event evt)
        {          
            _context.Add(evt);
            _context.SaveChanges();
        }
        public List<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public void DeleteEvent(int id)
        {
            _context.Events.Remove(GetEvent(id));
            _context.SaveChanges();
        }
        public Event GetEvent(int id)
        {
            return _context.Events.Find(id);
        }
        public void UpdateEvent(Event @evt)
        {
                 Event  oldEvent = _context.Events.Find(evt.Id);
                       oldEvent.Id = evt.Id;
                       oldEvent.Name = evt.Name;
                       oldEvent.City = evt.City;
                       oldEvent.Description = evt.Description;
                       oldEvent.DateTime = evt.DateTime;
                       oldEvent.CountryCode = evt.CountryCode;
                     _context.Events.Update(oldEvent);
        }

        public List<Event> FilterEventsByCity(string city)
        {
            return _context.Events.Where(ev => ev.City == city).ToList();        
        }

        public List<Event> SearchEventsByCountryCode(string code)
        {
         return    _context.Events.Where(ev => ev.CountryCode == code).ToList();
        }
    }
}
