using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventMaker_JsonChapter1.Models;
using EventMaker_JsonChapter1.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventMaker_JsonChapter1.Pages.Events
{
    public class IndexEventModel : PageModel
    {
        IEventService repo;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexEventModel(IEventService repository)
        {
            repo = repository;
        }
        public List<Event> Events { get; private set; }
        public async Task<IActionResult> OnGetAsync()
        {      
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = await  repo.FilterEventsByCityAsync(FilterCriteria);
            }
            else
            Events = await repo.GetAllEventsAsync();
            return Page();
        }
        public async Task<IActionResult> OnGetMyEventsAsync(string  code)
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