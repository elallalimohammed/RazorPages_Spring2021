
using EventMaker_EFChapter2.Helpers.CountryHelpers;
using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EventMaker_EFChapter2.Services.Interface
{
    public class JsonCountryService : ICountryService
    {
        string JsonFileName = @"C:\Users\EASJ\Documents\DeskTop\ASP.NET RAZOR PAGES\For_Final_Project\ORIGINALS\RazorPagesEventMaker\wwwroot\Data\JsonCountries.json";

        public List<Country> GetAllCountries()
        {
            List<Country> returnList = JsonFileCountryReader.ReadJson(JsonFileName);
            return returnList;
        }
        public void AddCountry(Country country)
        {
            List<Country> countries = GetAllCountries().ToList();
            if (country != null)
            {
                countries.Add(country);
                JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
            }
        }
        public Country GetCountry(string code)
        {
            foreach (var c in GetAllCountries())
            {
                if (c.Code == code)
                    return c;
            }
            return new Country();
        }
        public void DeleteCountry(string code)
        {
            List<Country> countries = GetAllCountries().ToList();

            foreach (var c in countries)
            {
                if (c.Code == code)
                {
                    countries.Remove(c);
                    break;
                }
            }
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }        
    }
}
