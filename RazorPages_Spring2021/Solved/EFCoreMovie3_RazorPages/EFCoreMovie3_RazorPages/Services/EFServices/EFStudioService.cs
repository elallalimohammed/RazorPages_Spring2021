using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie3_RazorPages.Services.EFServices
{
    public class EFStudioService:IStudioService
    {
        MovieDBContext context;
        public EFStudioService(MovieDBContext service)
        {
            context = service;
        }
        public void  AddStudio(Studio studio)
        {
            context.Studios.Add(studio);
            context.SaveChangesAsync();
        }
        public  Studio  GetStudioById(int id)
        {
            return  context.Studios.Find(id);
        }
        public void DeleteStudio(Studio studio)
        {
            if (studio != null)
            {
                context.Studios.Remove(studio);
                 context.SaveChanges();
            }
        }
        public IEnumerable<Studio> GetStudios(string filter)
        {
            return this.context.Set<Studio>().Where(s => s.Name.StartsWith(filter)).AsNoTracking().ToList();
        }
        public IEnumerable<Studio> GetStudios()
        {
            return context.Studios;
        }
    }
}
