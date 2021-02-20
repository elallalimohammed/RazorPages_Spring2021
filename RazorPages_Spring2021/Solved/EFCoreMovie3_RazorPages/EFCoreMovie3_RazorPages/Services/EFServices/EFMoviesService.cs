using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie3_RazorPages.Services.EFServices
{
    public class EFMoviesService:IMovieService
    {
        MovieDBContext context;
        public EFMoviesService(MovieDBContext service)
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
        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public Studio GetMoviesByStudioId(int id)
        {
            Studio Studio = context.Set<Studio>()
                .Include(m=> m.Movies)
                 .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
            return Studio;
        }
    }
}
