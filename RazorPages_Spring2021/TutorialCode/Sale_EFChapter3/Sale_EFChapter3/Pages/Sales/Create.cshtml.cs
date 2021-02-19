using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sale_EFChapter3.Models;
using Sale_EFChapter3.Services.Interfaces;


namespace Sale_EFChapter3.Pages.Sales
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
          await  saleService.AddSaleAsync(Sale);
          return RedirectToPage("GetAllSales");
        }
    }
}