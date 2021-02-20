using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie3_RazorPages
{
    public class StudioMoviesModel : PageModel
    {
        IMovieService   movieService;
        public Studio Studio { get; set; } = new Studio();
        public StudioMoviesModel(IMovieService service)
        {
            this.movieService = service;
        }
        public void  OnGetAsync(int id)
        {
            Studio = movieService.GetMoviesByStudioId(id);
        }
    }
}