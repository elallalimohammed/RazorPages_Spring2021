using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie3_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie3_RazorPages.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        public Movie Movie { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
    }
}