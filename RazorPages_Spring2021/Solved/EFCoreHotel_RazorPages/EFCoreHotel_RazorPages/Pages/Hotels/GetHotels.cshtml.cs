using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages
{
    public class GetHotelsModel : PageModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
     
        IHotelService hService;
        public GetHotelsModel(IHotelService service)
        {
            hService = service;
        }
        public void OnGet()
        {
            if ( !String.IsNullOrEmpty(FilterCriteria))
            {
                Hotels = hService.FilterHotelsByCity(FilterCriteria);
            }
            else
                Hotels = hService.GetHotels();
        }
    }
}