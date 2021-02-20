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
    public class EditEventModel : PageModel
    {
        IEventService repo;
        [BindProperty]
        public Event Event { get; set; }
        public EditEventModel(IEventService repository)
        {
            repo = repository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Event = await repo.GetEventAsync(id);
            if (Event == null)
            {
                return null;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await repo.UpdateEventAsync(Event);
            return RedirectToPage("IndexEvent");
        }
    }
}