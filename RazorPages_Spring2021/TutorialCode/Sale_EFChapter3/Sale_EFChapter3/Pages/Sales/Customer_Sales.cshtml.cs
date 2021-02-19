using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sale_EFChapter3.Models;
using Sale_EFChapter3.Services.Interfaces;


namespace Sale_EFChapter3.Pages.Sales
{
    public class Customer_SalesModel : PageModel
    {         
        ISaleService saleService;
       public Customer Customer { get; set; }
        public Customer_SalesModel(ISaleService service)
        {
            this.saleService = service;
        }
        public  async Task OnGetAsync(int id)
        {          
         Customer =  await saleService.GetSalesByCustomerIdAsync(id);
        }
    }
}