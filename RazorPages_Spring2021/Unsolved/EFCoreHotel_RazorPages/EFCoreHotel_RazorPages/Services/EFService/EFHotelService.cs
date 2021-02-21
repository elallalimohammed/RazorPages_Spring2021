using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFHotelService:IHotelService
    {
        private  HoteldbContext  context;
        public EFHotelService(HoteldbContext service)
        {
            context = service;
        }
        public IEnumerable<Hotel> GetHotels()
        {
            return context.Hotels;
        }
    }
}
