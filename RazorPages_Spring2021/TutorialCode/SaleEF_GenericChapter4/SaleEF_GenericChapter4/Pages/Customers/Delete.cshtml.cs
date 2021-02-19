using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Customers
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
                Customer = await customerService.GetItemByIdAsync(id);
         } 

        public async  Task<IActionResult> OnPost()
        {
           await    customerService.DeleteItemAsync(Customer);

            return RedirectToPage("GetAllCustomers");
        }
    }
}