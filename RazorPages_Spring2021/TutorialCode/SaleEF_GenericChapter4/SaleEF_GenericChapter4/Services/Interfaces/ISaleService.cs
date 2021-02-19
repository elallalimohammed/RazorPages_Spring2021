using SaleEF_GenericChapter4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleEF_GenericChapter4.Services.Interfaces
{
   public interface ISaleService : IService<Sale>
    {
         Task<IEnumerable<Sale>> GetSalesAsync(int maxAmount);
         Task<Customer> GetSalesByCustomerAsync(int id);
    }
}
