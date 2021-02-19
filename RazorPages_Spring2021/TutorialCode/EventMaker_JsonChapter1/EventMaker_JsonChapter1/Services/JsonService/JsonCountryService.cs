
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
        private JsonFileService<Country> jsonCustomerService { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Countries.json"); }
        }

        public JsonCountryService(JsonFileService<Country> jsonFileCustomerService,
                                       IWebHostEnvironment webHostEnvironment)
        {
            jsonCustomerService = jsonFileCustomerService;
            WebHostEnvironment = webHostEnvironment;
            jsonCustomerService.FileName = JsonFileName;
            countries = jsonCustomerService.LoadAsync().Result;
           
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await jsonCustomerService.LoadAsync();
        }
        public async Task AddCountryAsync(Country country)
        {           
            if (country != null)
            {
                countries.Add(country);
                await jsonCustomerService.SaveAsync(countries);
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
            await  jsonCustomerService.SaveAsync(countries); 
        }
    }
}
