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
    public class DeleteEventModel : PageModel
    {
        IEventService repo;
        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventModel(IEventService repository)
        {
            repo = repository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Event = await repo.GetEventAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
             await  repo.DeleteEventAsync(id);
            return RedirectToPage("IndexEvent");
        }

    }
}