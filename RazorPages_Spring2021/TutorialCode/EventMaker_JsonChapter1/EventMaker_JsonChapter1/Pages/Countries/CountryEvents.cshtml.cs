using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventMaker_JsonChapter1.Models;
using EventMaker_JsonChapter1.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventMaker_JsonChapter1.Pages.Countries
{
    public class CountryEventsModel : PageModel
    {
        IEventService repo;
        public List<Event> Events { get; private set; }
        public CountryEventsModel(IEventService repository)
        {
            repo = repository;
        }
        public async Task<IActionResult> OnGetAsync(string code)
        {
            Events = new List<Event>();
            if (code == null)
            {
                return NotFound();
            }
            Events = await repo.SearchEventsByCountryCodeAsync(code);
            if (Events == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}