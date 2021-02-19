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
    public class DeleteEventModel : PageModel
    {
        IEventService repo;
        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventModel(IEventService repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
              repo.DeleteEvent(id);
            return RedirectToPage("Index");
        }

    }
}