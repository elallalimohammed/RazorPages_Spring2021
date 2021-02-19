using SaleEF_GenericChapter4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleEF_GenericChapter4.Services.Interfaces
{
   public interface ICustomerService:IService<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(string filter);
    }
}
