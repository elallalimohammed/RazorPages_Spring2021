using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie2_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie2_RazorPages.Pages.Movies
{
    public class GetMoviesModel : PageModel
    {
        public string FilterCriteria { get; set; }
         public IEnumerable<Movie> Movies { get; set; }
        private MovieDBContext context;

        public GetMoviesModel(MovieDBContext service)
        {
            context = service;
        }
        public void OnGet()
        {
            Movies = context.Movies;
        }
        public void OnPost()
        {

        }
    }
}