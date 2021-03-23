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
    public class GetRoomsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
       public Room Room { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public int Count { get { return Rooms.Count(); } }


        IRoomService rService;
        public GetRoomsModel(IRoomService service)
        {
            rService = service;
        }
        public void OnGet()
        {
            if (Room.Price > 0 || !String.IsNullOrEmpty(Room.Types))
            {
                Rooms = rService.GetRooms(Room.Price, Room.Types);
            }
            else
                Rooms = rService.GetRooms();
        }
        public void OnGetHotelRooms(int  id)
        {
            Rooms = rService.GetRoomsPerHotel( id);          
        }
    }
}