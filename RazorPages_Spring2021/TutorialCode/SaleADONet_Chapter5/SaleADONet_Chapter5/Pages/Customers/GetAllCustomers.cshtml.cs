using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleADONet_Chapter5.Models;
using SaleADONet_Chapter5.Services.Interfaces;

namespace SaleADONet_Chapter5.Pages.Customers
{
    public class GetAllCustomersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
         public IEnumerable<Customer> Customers { get; private set; }

        ICustomerService customerService;
        public GetAllCustomersModel(ICustomerService cService )
        {
            this.customerService = cService;          
        }
        public  async Task OnGetAsync()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Customers = await customerService.GetCustomersByNameAsync(FilterCriteria);
            }
            else
                Customers = await customerService.GetCustomersAsync();
        }     
    }
}