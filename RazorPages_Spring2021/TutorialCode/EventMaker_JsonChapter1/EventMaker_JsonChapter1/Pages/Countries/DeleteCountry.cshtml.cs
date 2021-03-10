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
    public class DeleteCountryModel : PageModel
    {
        ICountryService repo;

        [BindProperty]
        public Country Country { get; set; }

        public DeleteCountryModel(ICountryService  repository)
        {
            repo = repository;
        }
        public async Task<IActionResult>  OnGetAsync(string code)
        {
            Country = await repo.GetCountryAsync(code);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string code)
        {
            if (Country != null)
            {
                await repo.DeleteCountryAsync(code);
            }

            return RedirectToPage("IndexCountry");
        }
    }
}