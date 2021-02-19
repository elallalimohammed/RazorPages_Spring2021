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
    public class IndexCountryModel : PageModel
    {
        ICountryService repo;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexCountryModel(ICountryService repository)
        {
            repo = repository;
        }

        public List<Country> Countries { get; private set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Countries =await  repo.GetAllCountriesAsync();
            return Page();
        }
    }
}