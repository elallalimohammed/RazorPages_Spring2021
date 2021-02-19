using SaleADONet_Chapter5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace SaleADONet_Chapter5.Services.Interfaces
{
   public interface ISaleService
    {
        Task<IEnumerable<Sale>>  GetSalesByAmountAsync(int maxAmount);
        Task<IEnumerable<Sale>> GetSalesAsync();
        Task AddSaleAsync(Sale sale);
         Task DeleteSaleAsync(Sale sale);

        Task<Sale> GetSaleByIdAsync(int id);
        Task <List<Sale>> GetSalesByCustomerIdAsync(int CustomerId);
    }
}
