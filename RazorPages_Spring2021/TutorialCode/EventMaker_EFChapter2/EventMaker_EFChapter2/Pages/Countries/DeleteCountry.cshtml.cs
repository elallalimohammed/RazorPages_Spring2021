using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventMaker_EFChapter2.Models;
using EventMaker_EFChapter2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventMaker_EFChapter2.Pages.Countries
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
        public IActionResult OnGet(string code)
        {
            Country = repo.GetCountry(code);
            return Page();
        }

        public IActionResult OnPost(string code)
        {
            if (Country != null)
            {
                repo.DeleteCountry(code);
            }

            return RedirectToPage("IndexCountry");
        }
    }
}