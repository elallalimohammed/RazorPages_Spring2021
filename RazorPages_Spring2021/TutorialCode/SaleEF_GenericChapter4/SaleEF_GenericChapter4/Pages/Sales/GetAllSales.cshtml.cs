using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;

namespace SaleEF_GenericChapter4.Pages.Sales
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
            Sales = await saleService.GetItemsAsync();
        }

        public async Task OnGetMySalesAsync( int id)
        {
             Customer = await saleService.GetSalesByCustomerAsync(id);
        }
    }
}