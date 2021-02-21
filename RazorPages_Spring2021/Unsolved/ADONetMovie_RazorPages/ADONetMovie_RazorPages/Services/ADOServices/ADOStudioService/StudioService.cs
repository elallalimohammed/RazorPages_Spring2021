
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOStudioService
{
    public class StudioService :IStudioService
    {
         private AdonetStudioService studioService;
        public StudioService(AdonetStudioService service)
        {
            studioService = service;
        }
        public IEnumerable<Studio> GetStudios()
        {
            return studioService.GetAllStudios();
        }
    }
}
