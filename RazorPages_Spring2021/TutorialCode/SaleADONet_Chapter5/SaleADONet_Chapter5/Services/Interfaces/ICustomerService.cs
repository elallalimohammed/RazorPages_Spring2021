
using SaleADONet_Chapter5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  SaleADONet_Chapter5.Services.Interfaces
{
   public interface ICustomerService
    {
       Task< IEnumerable<Customer>> GetCustomersByNameAsync(string name);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task  DeleteCustomerAsync(Customer customer);
         Task<Customer> GetCustomerByIdAsync(int id);
    }
}
