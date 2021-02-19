using EventMaker_JsonChapter1.Models;
using EventMaker_JsonChapter1.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Pages.Countries
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await repo.AddCountryAsync(Country);
            return RedirectToPage("IndexCountry");
        }
    }
}