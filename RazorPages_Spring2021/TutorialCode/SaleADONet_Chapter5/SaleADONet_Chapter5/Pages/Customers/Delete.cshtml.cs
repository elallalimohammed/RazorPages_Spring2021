using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleADONet_Chapter5.Models;
using SaleADONet_Chapter5.Services.Interfaces;

namespace SaleADONet_Chapter5.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        ICustomerService customerService;
        public DeleteModel(ICustomerService service)
        {
            this.customerService = service;
        }
        public async Task OnGetAsync(int id)
        {
            Customer = await customerService.GetCustomerByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await customerService.DeleteCustomerAsync(Customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}

