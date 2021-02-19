using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sale_EFChapter3.Models;
using Sale_EFChapter3.Services.Interfaces;


namespace Sale_EFChapter3.Pages.Customers
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
            try
            {
                Customer = await customerService.GetCustomerByIdAsync(id);
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                RedirectToPage("Pages/Delete", new { id, saveChangesError = true });
            }

            //    [BindProperty]

            //public string ErrorMessage { get; set; }

            //public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    Customer = await cust _context.Students
            //        .AsNoTracking()
            //        .FirstOrDefaultAsync(m => m.ID == id);

            //    if (Student == null)
            //    {
            //        return NotFound();
            //    }

            //    if (saveChangesError.GetValueOrDefault())
            //    {
            //        ErrorMessage = "Delete failed. Try again";
            //    }

            //return Page();
        }

    

        public async  Task<IActionResult> OnPost()
        {
           await    customerService.DeleteCustomerAsync(Customer);

            return RedirectToPage("GetAllCustomers");
        }
    }
}