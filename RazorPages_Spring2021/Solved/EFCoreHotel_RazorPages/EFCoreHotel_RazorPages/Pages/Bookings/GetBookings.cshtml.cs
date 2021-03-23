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
    public class GetBookingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime? Date{ get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int Count {
            get
            {
                return Bookings.Count();
            } 
        }

        IBookingService bService;
        public GetBookingsModel(IBookingService service)
        {
            bService = service;
        }
        public void OnGet()
        {      
            if (Date.HasValue)
            {
                Bookings = bService.FilterBookingsByDate(Date);
            }
            else
            Bookings = bService.GetBookings();           
        }
        public void OnGetGuestBookings(int id)
        {
            Bookings = bService.GetBookingsPerGuest(id);
        }
        public void OnGetBookingsPerHotelPerRoom(int id1, int id2)
        {
            Bookings = bService.GetBookingsPerHotelPerRoom(id1, id2);
        }
    }
}