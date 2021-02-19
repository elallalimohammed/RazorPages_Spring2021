using Sale_EFChapter3.Models;
using Sale_RazorPagesApp.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sale_EFChapter3.Services.Interfaces
{
   public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(string filter);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task  DeleteCustomerAsync(Customer customer);
         Task<Customer> GetCustomerByIdAsync(int id);
    }
}
