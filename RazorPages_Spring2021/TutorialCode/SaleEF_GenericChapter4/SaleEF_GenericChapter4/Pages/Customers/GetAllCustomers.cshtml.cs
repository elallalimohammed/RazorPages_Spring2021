using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Customers
{
    public class GetAllCustomersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }    
        public string CookieValue { get; set; }
        public IEnumerable<Customer> Customers { get; private set; }
        
        ICustomerService customerService;       
        public GetAllCustomersModel(ICustomerService service )
        {
            this.customerService = service;
            Customers = new List<Customer>();
        }
        public async  Task  OnGetAsync ()
        {        
            if (string.IsNullOrEmpty(FilterCriteria))
            {
                Customers = await customerService.GetItemsAsync(); 
            }
            else
            Customers = await customerService.GetCustomersAsync(FilterCriteria);
        }
    }
}