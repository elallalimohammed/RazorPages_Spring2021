using EventMaker_JsonChapter1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Services.Interface
{
  public  interface ICountryService
    {
       Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryAsync(string code);
       Task DeleteCountryAsync(string code);
        Task AddCountryAsync(Country country);
    }
}
