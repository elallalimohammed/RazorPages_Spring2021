using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFGuestService:IGuestService
    {
        private HoteldbContext context;
        public EFGuestService(HoteldbContext service)
        {
            context = service;
        }
        public IEnumerable<Guest> GetGuests()
        {
            return context.Guests;
        }
    }
}
