
using EventMaker_JsonChapter1.Models;
using EventMaker_JsonChapter1.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Services.JsonService
{
    public class JsonCountryService : ICountryService
    {
        private List<Country> countries;
        private JsonFileService<Country> jsonService { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Countries.json"); }
        }

        public JsonCountryService(JsonFileService<Country> jsonFileCustomerService,
                                       IWebHostEnvironment webHostEnvironment)
        {
            jsonService = jsonFileCustomerService;
            WebHostEnvironment = webHostEnvironment;
            jsonService.FileName = JsonFileName;
            countries = jsonService.LoadAsync().Result;        
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await jsonService.LoadAsync();
        }
        public async Task AddCountryAsync(Country country)
        {           
            if (country != null)
            {
                countries.Add(country);
                await jsonService.SaveAsync(countries);
            }
        }
        public async Task<Country>  GetCountryAsync(string code)
        {
            foreach (var c in await GetAllCountriesAsync())
            {
                if (c.Code == code)
                    return c;
            }
            return new Country();
        }
        public async Task DeleteCountryAsync (string code)
        {
            List<Country> countries = await GetAllCountriesAsync();

            foreach (var c in countries)
            {
                if (c.Code == code)
                {
                    countries.Remove(c);
                    break;
                }
            }
            await  jsonService.SaveAsync(countries); 
        }
    }
}
