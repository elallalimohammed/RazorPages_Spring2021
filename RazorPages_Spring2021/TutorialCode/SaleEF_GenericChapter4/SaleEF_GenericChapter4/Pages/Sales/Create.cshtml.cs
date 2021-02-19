using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Sales
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Sale Sale { get; set; } = new Sale();

        ISaleService saleService;
        public CreateModel(ISaleService service)
        {
            this.saleService = service;
        }
        public IActionResult  OnGet(int id)
        {         
            Sale.CustomerId = id;      
            return Page();
        }      
        public async Task<IActionResult>  OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }  
          await  saleService.AddItemAsync(Sale);
          return RedirectToPage("GetAllSales");
        }
    }
}