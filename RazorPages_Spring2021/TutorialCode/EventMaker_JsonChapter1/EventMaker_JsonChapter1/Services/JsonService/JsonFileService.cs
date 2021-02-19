using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Services.JsonService
{
    public class JsonFileService<T>  where T : class
    {
        public string FileName { get; set; }
        public async Task SaveAsync(List<T> data)
        {       
           using (FileStream inputStream= File.Create(FileName))
            {
                await JsonSerializer.SerializeAsync<T[]>(inputStream, data.ToArray(),  new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }        
        }
        public async Task<List<T>> LoadAsync()
        {
            using (FileStream output = File.OpenRead(FileName))
            {
                try
                {
                     return  await JsonSerializer.DeserializeAsync<List<T>>(output);
                }
                catch (FileNotFoundException)
                {
                    await SaveAsync(new List<T>());
                    return new List<T>();
                }
            }
        }
    }
}