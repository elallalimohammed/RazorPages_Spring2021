using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleADONet_Chapter5.Models;
using SaleADONet_Chapter5.Services.Interfaces;

namespace  SaleADONet_Chapter5.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        ICustomerService customerService;
        public CreateModel(ICustomerService service)
        {
            this.customerService = service;
        }    
        public async Task  OnGetAsync()
        {
        }
        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           await  customerService.AddCustomerAsync(customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}