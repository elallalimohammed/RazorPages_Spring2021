using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Helpers.CountryHelpers
{
    public class JsonFileCountryWritter
    {
        public static void WriteToJson(List<Country> countries, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(countries, 
                                                                       Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
