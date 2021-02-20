using EFCoreMovie_RazorPages.Services.Interfaces;
using EFCoreMovie2_RazorPages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie_RazorPages.Services.EFServices
{
    public class EFMovieService:IMovieService
    {
        MovieDBContext context;
        public EFMovieService(MovieDBContext service)
        {
            context = service;
        }
        public IEnumerable<Movie>  GetMovies(string filter)
        {
            return this.context.Set<Movie>().Where(s => s.Title.StartsWith(filter)).AsNoTracking().ToList();
        }
        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies;
        }
    }
}
