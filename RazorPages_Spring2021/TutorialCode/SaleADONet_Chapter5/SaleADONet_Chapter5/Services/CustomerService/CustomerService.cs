using SaleADONet_Chapter5.Models;
using SaleADONet_Chapter5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleADONet_Chapter5.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private ADO_CustomerService customerService { get; set; }
        public CustomerService(ADO_CustomerService service)
        {
            customerService = service;
        }      
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await customerService.GetAllCustomersAsync();
        }
        public async Task<IEnumerable<Customer>> GetCustomersByNameAsync(string name)
        {
            return await customerService.CustomersByNameAsync(name);
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await customerService.NewCustomerAsync(customer);
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await customerService.GetCustomerAsync(id);
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
           await  customerService.DeleteThisCustomerAsync(customer);
        }

        
    }
}