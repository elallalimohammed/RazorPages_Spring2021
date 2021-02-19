using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Sales
{
    public class DeleteModel : PageModel
    {
        ISaleService saleService;
        public DeleteModel(ISaleService sService)
        {
            this.saleService = sService;
        }
        [BindProperty]
        public Sale Sale { get; set; }
        public async Task  OnGetAsync(int id)
        {     
               Sale= await saleService.GetItemByIdAsync(id);           
        }

        public async Task<IActionResult> OnPostAsync()
        {
          await  saleService.DeleteItemAsync(Sale);

            return RedirectToPage("GetAllSales");
        }
    }
}