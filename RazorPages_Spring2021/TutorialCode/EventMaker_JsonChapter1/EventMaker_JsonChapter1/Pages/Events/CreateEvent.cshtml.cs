using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using EventMaker_JsonChapter1.Services.Interface;
using EventMaker_JsonChapter1.Models;

namespace EventMaker_JsonChapter1.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        IEventService eRepo;
        [BindProperty]
        public Event Event { get; set; }

        [BindProperty]
        public string CountryCode { get; set; }
        //public SelectList CountryCodes { get; set; }

        public CreateEventModel(IEventService eService )
        {
            eRepo = eService;
            Event = new Event();     
        }
        public async Task<IActionResult>  OnGetAsync(string Code)
        {
            Event.CountryCode = Code;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await eRepo.AddEventAsync(Event);
            return RedirectToPage("Index");
        }
    }

}