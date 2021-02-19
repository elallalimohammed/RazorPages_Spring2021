using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sale_EFChapter3.Models;
using Sale_EFChapter3.Services.Interfaces;
using Sale_RazorPagesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sale_EFChapter3.Services.EFService
{
    public class EFCustomerService:ICustomerService
    {
        private List<Customer> customers;
        private SaleDbContext context; 
        public EFCustomerService(SaleDbContext saleContext)
        {
            context = saleContext;
           // customers = context.Customers.AsNoTracking().ToList();
        }
        public async Task AddCustomerAsync(Customer customer)
        { 
            context.Customers.Add(customer);
             await context.SaveChangesAsync();     
        }  
        public async Task<Customer> GetCustomerByIdAsync(int  id)
        {
           return await context.Customers.FindAsync(id);         
         }
        public async Task DeleteCustomerAsync(Customer customer)
        {   
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }  
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync(string name)
        {
            return await context.Customers.Where(s => s.Name.StartsWith(name)).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }
    }
}

