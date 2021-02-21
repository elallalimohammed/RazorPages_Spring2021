using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Movies
{
    public class GetMoviesModel : PageModel
    {
         public IEnumerable<Movie> Movies { get; set; }

        IMovieService movieService { get; set; }
        public GetMoviesModel(IMovieService service)
        {
            movieService = service;
         }
        public void OnGet()
        {         
            Movies = movieService.GetMovies();
        }

    }
}