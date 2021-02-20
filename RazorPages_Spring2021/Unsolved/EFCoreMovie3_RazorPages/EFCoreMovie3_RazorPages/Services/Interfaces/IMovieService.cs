using EFCoreMovie3_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie3_RazorPages.Services.Interfaces
{
    public interface IMovieService
    {
        
            IEnumerable<Movie> GetMovies(string filter);
            IEnumerable<Movie> GetMovies();
            
        //Task AddCustomerAsync(Customer customer);
            //Task DeleteCustomerAsync(Customer customer);
            //Task<Customer> GetCustomerByIdAsync(int id);
        
    }
}
