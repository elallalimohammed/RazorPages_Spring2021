using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie3_RazorPages.Pages.Studios
{
    public class CreateModel : PageModel
    {       
        [BindProperty]
        public Studio Studio { get; set; }

        IStudioService studioService;
        public CreateModel(IStudioService service)
        {
            this.studioService = service;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            studioService.AddStudio(Studio);
            return RedirectToPage("GetStudios");
        }
    }
}