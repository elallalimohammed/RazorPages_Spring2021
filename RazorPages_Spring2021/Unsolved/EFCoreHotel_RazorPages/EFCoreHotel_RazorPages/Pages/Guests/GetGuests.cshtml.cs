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
    public class GetGuestsModel : PageModel
    {
        public IEnumerable<Guest> Guests{ get; set; }
      
        IGuestService guestService;
        public GetGuestsModel(IGuestService service)
        {
            guestService = service;
        }
        public void OnGet()
        {
            Guests = guestService.GetGuests();
        }
    }
}