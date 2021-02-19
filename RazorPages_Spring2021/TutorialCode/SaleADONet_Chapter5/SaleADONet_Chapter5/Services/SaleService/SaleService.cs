using SaleADONet_Chapter5.Models;
using SaleADONet_Chapter5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleADONet_Chapter5.Services.SaleService
{
    public class SaleService  :ISaleService
    {
         private ADO_SaleService saleService { get; set; }
        public SaleService(ADO_SaleService service)
        {
            saleService = service;
         }
        public async Task AddSaleAsync(Sale sale)
        {           
              await  saleService.AddSaleAsync(sale);
        }
        public  async Task< IEnumerable<Sale>> GetSalesAsync()
        {
            return await saleService.GetAllSalesAsync();
        }
        public async Task DeleteSaleAsync(Sale sale)
        {       
            await saleService.DeleteSaleAsync(sale);
        }
        public async  Task<IEnumerable<Sale>> GetSalesByAmountAsync(int maxAmount)
        {
            return await  saleService.GetSalesByAmountAsync(maxAmount);
        }
        public async Task<List<Sale>> GetSalesByCustomerIdAsync(int customerId)
        {
           return await saleService.GetSalesByCustomerIdAsync(customerId);      
        }
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await saleService.GetSaleByIdAsync(id);
        }
    }
}
