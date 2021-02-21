using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Studios
{
    public class GetStudiosModel : PageModel
    {
       
        private IStudioService studioService;
        public GetStudiosModel(IStudioService service)
        {
            studioService = service;
        }      
        public IEnumerable<Studio> Studios { get; set; } = new List<Studio>();
        public void OnGet()
        {
            Studios = studioService.GetStudios();
        }
     }
}