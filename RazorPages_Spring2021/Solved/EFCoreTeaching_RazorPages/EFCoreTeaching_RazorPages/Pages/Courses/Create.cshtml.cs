using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreTeaching_RazorPages.Pages.Courses
{
    public class CreateModel : PageModel
    {
        //public int SId { get; set; }
        //public int CId { get; set; }

        public void OnGet(int cid)
        {
           // CId= cid;
        }

        [BindProperty]
        public Course Course { get; set; }
        ICourseService  courseService;
        public CreateModel(ICourseService service)
        {
            this.courseService = service;
        }
        public IActionResult OnPostAsync(Course course)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            courseService.AddCourse(course);
            return RedirectToPage("GetCourses" );
        }
    }
}