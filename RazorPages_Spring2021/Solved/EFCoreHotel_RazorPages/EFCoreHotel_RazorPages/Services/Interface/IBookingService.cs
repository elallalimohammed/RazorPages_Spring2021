using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
   public  interface IBookingService
    {
        public IEnumerable<Booking> GetBookings();
        public IEnumerable<Booking> FilterBookingsByDate(DateTime?  date);
        public IEnumerable<Booking> GetBookingsPerGuest(int gid);
        public IEnumerable<Booking> GetBookingsPerHotelPerRoom(int hid, int rid);
    }
}
