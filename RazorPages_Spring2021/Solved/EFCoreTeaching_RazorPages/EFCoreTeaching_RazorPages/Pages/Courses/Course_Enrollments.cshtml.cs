using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreTeaching_RazorPages
{
    public class Course_EnrollmentsModel : PageModel
    {
        ICourseService context;
        public Course_EnrollmentsModel(ICourseService service)
        {
            context = service;
        }
        public Course Course { get; set; }
        public IActionResult OnGet(int cid)
        {
            Course = context.GetCourse(cid);
            if (Course== null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}