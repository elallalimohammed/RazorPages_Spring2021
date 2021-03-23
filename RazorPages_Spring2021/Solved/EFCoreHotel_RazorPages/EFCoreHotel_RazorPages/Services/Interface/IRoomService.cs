using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
  public  interface IRoomService
    {
        public IEnumerable<Room> GetRooms();
        IEnumerable<Booking> GetBookingByRoomByHotel(int id1, int id2);
        IEnumerable<Room> GetRoomsPerHotel(int id1);
       IEnumerable<Room>  GetRooms(double Price , string Types);
    }
}
