using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFRoomService : IRoomService
    {
        private HoteldbContext context;
        public EFRoomService(HoteldbContext service)
        {
            context = service;
        }

        public IEnumerable<Room> GetRooms()
        {
            return context.Rooms;
        }
        public IEnumerable<Booking> GetBookingByRoomByHotel(int id1, int id2)
        {
            Room room = context.Rooms
            .Include(b => b.Bookings)
            .AsNoTracking()
            .FirstOrDefault(m => m.RoomNo == id2 && m.HotelNo == id1);

            var Bookings = from booking in room.Bookings
                           select booking;
            return Bookings;
        }
        public IEnumerable<Room> GetRoomsPerHotel(int id)
        {
            return context.Rooms.Where(r => r.HotelNo == id);
        }
        public IEnumerable<Room> GetRooms(double price, string types)
        {
            if(price>0 && types==null)
            return context.Rooms.Where(r => r.Price<=price);
            else if(price==0 && types!=null)
                return context.Rooms.Where(r => r.Types==types);
            else
                return context.Rooms.Where(r => r.Price <= price && r.Types==types);
        }
    }
}
