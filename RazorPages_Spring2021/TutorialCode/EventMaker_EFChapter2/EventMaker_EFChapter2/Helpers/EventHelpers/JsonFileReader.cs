using EventMaker_EFChapter2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventMaker_EFChapter2.Helpers.EventHelpers
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Event>>(jsonString);
        }
    }
}
