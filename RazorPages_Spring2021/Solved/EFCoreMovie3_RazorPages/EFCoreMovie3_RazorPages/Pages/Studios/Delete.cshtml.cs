using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie3_RazorPages.Pages.Studios
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Studio Studio  { get; set; }

        IStudioService studioService;

        public DeleteModel(IStudioService service)
        {
            this.studioService = service;
        }
        public void OnGet(int id)
        {
            Studio =studioService.GetStudioById(id);      
        }
        public IActionResult  OnPost()
        {
            studioService.DeleteStudio(Studio);

            return RedirectToPage("GetStudios");
        }
    }
}