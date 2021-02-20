using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie3_RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = new Movie();
        public void OnGet(int id)
        {
            Movie.StudioId = id;
        }       
        IMovieService movieService;
        public CreateModel(IMovieService service)
        {
            this.movieService = service;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            movieService.AddMovie(Movie);
            return RedirectToPage("GetMovies");
        }
    }
}