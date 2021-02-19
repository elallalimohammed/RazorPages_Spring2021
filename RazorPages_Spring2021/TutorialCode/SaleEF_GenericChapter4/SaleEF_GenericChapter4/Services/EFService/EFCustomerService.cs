using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleEF_GenericChapter4.Services.EFService
{
    public class EFCustomerService:   GenericSaleService<Customer>, ICustomerService
    {
        private List<Customer> customers;
        private SaleDbContext customerService { get; set; }

        public EFCustomerService(SaleDbContext service) :base(service)
        {
            customerService = service;
            customers = customerService.Customers.AsNoTracking().ToList();
        }
      public async Task<IEnumerable<Customer>> GetCustomersAsync(string name)
    {
        if (!String.IsNullOrEmpty(name))
        {
                return await CheckExpressionAsync(customer => customer.Name.StartsWith(name));
        }
            return customers;
    }

}}

