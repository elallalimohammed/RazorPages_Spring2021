using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Helpers.CountryHelpers
{
    public class JsonFileCountryReader
    {
        public static List<Country> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Country>>(jsonString);
        }
    }
}
