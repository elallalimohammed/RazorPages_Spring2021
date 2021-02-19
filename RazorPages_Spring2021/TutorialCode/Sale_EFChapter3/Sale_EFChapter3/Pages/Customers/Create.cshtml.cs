using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sale_EFChapter3.Models;
using Sale_EFChapter3.Services.Interfaces;


namespace Sale_EFChapter3.Pages.Customers
{
    public class CreateModel : PageModel
    {          
        public async void OnGetAsync (Customer c)
        {
            Customer= c;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        ICustomerService customerService;
        public CreateModel(ICustomerService service)
        {
            this.customerService = service;
        }
        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                 return Page();
            }
           await  customerService.AddCustomerAsync(customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}