
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOMovieService
{
    public class MovieService : IMovieService
    {
        private AdonetMovieService movieService;
       
        public MovieService(AdonetMovieService service)
        {
            movieService = service;
        }
         public IEnumerable<Movie> GetMovies()
        {
            return movieService.GetAllMovies();
        }      
    }
}
