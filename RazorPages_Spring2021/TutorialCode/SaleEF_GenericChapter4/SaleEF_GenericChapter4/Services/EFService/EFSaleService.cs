using Microsoft.EntityFrameworkCore;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleEF_GenericChapter4.Services.EFService
{
    public class EFSaleService : GenericSaleService<Sale>, ISaleService
    {
        private SaleDbContext saleService { get; set; }

        public EFSaleService(SaleDbContext service) : base(service)
        {
          saleService = service;
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {         
                return await  saleService.Sales.AsNoTracking().ToListAsync();
        }
        public async Task<Customer> GetSalesByCustomerAsync(int id)
        {      
            Customer Customer = await saleService.Customers
                .Include(s => s.Sales)  
                 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            
            if (Customer == null)
            {
                return null;
            }
            return Customer;
        }
        public async Task<IEnumerable<Sale>> GetSalesAsync(int maxAmount)
        {
            if (maxAmount > 0)
            {
                return await CheckExpressionAsync(sale => sale.Amount < maxAmount);
            }
            else
                return await GetSalesAsync();
        }
    }
}

