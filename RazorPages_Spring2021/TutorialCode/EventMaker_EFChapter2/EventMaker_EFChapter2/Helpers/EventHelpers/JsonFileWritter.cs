﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using EventMaker_EFChapter2.Models;

namespace EventMaker_EFChapter2.Helpers.EventHelpers
{
    public class JsonFileWritter
    {
        public static void WriteToJson(List<Event> @events, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(@events, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
