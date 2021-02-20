using EFCoreMovie3_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie3_RazorPages.Services.Interfaces
{
    public interface IStudioService
    {
        IEnumerable<Studio> GetStudios(string filter);
        IEnumerable<Studio> GetStudios();
        void  AddStudio(Studio studio);
        void  DeleteStudio(Studio studio);
        Studio  GetStudioById(int id);
    }
}
