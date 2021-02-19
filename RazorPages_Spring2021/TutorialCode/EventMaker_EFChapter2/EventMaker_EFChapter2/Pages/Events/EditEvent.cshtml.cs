using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventMaker_EFChapter2.Models;
using EventMaker_EFChapter2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventMaker_EFChapter2.Pages.Events
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
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            if (Event == null)
            {
                return null;
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateEvent(Event);
            return RedirectToPage("Index");
        }
    }
}