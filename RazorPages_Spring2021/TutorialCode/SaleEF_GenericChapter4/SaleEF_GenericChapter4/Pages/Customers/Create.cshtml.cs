using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Customers
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
           await  customerService.AddItemAsync(customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}