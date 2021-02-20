using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie_RazorPages.Services.Interfaces;
using EFCoreMovie2_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie2_RazorPages.Pages.Movies
{
    public class GetMoviesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        IMovieService movieService;
        public GetMoviesModel(IMovieService service)
        {
            movieService = service;
         }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Movies = movieService.GetMovies(FilterCriteria);
            }
            else
                Movies= movieService.GetMovies();
        }
    }
}