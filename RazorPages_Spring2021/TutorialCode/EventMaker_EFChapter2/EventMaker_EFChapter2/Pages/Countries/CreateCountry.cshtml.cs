using EventMaker_EFChapter2.Models;
using EventMaker_EFChapter2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventMaker_EFChapter2.Pages.Countries
{
    public class CreateCountryModel : PageModel
    {
        ICountryService repo;
        [BindProperty]
        public Country Country { get; set; }
        public CreateCountryModel(ICountryService repository)
        {
            repo = repository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.AddCountry(Country);
            return RedirectToPage("IndexCountry");
        }
    }
}