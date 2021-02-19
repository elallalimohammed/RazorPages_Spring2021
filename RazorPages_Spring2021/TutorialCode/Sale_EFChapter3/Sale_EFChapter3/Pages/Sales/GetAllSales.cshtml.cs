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
    public class GetAllSalesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int  Amount { get; set; }

        public IEnumerable<Sale> Sales { get; private set; }

        //[BindProperty]
        //public Sale Sale { get;  set; }

        [BindProperty]
        public Customer Customer { get; set; }

        ISaleService saleService;
        public GetAllSalesModel(ISaleService service)
        {
            this.saleService = service;
        }
        public async Task OnGetAsync()
        { 
           if (Amount>0 )
            {
                Sales = await saleService.GetSalesAsync(Amount);
            }
           else
            Sales = await saleService.GetSalesAsync();
        }

        public async Task OnGetMySalesAsync( int id)
        {
            //if (Amount > 0)
            //{
            //    Sales = await saleService.GetSalesAsync(Amount);
            //}
            //else
            //    Sales = await saleService.GetSalesAsync();

            Customer = await saleService.GetSalesByCustomerIdAsync(id);
        }
    }
}