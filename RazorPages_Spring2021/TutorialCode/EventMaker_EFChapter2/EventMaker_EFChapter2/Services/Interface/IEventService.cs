using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Services.Interface
{
   public  interface IEventService
    {
        List<Event> GetAllEvents();
        Event GetEvent(int id);
        void AddEvent(Event ev);
        void DeleteEvent(int id);
        void UpdateEvent(Event ev);
        List<Event> FilterEventsByCity(string city);
        List<Event> SearchEventsByCountryCode(string code);
    }
}
