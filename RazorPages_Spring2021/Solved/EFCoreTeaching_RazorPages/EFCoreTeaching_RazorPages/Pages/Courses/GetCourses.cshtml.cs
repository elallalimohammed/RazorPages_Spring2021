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
    public class GetCoursesModel : PageModel
    {
        public IEnumerable<Course> Courses { get; set; }
       public int  SId { get; set; }
        private ICourseService  context;
        public GetCoursesModel(ICourseService service)
        {
            context = service;
        }  
        public void OnGet(int  sid)
        {
            SId = sid;
            Courses = context.GetCourses();
        }
    }
}