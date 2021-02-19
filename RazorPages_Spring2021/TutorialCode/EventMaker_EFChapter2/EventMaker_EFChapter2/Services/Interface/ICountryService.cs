using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Services.Interface
{
  public  interface ICountryService
    {
        List<Country> GetAllCountries();
        Country GetCountry(string code);
        void DeleteCountry(string code);
        void AddCountry(Country country);
    }
}
