using EventMaker_EFChapter2.Models;
using EventMaker_EFChapter2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Services.DBFService
{
    public class CountryService:ICountryService
    {
        private EventMakerDBContext _context;

        public CountryService(EventMakerDBContext context)
        {
            _context = context;
        }
         public List<Country> GetAllCountries()
        {        
            return _context.Countries.ToList();
        }
        public void AddCountry(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
        }
        public Country GetCountry(string code)
        {
            return _context.Countries.FirstOrDefault(c => c.Code == code);
         }
        public void DeleteCountry(string code)
        {        
            _context.Remove(GetCountry(code));
            _context.SaveChanges();
        }
    }
}
