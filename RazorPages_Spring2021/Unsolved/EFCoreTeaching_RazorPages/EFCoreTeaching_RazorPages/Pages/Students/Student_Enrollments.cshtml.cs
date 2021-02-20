using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreTeaching_RazorPages.Pages.Students
{
    public class Student_EnrollmentsModel : PageModel
    {
        IStudentService context;
        public Student_EnrollmentsModel(IStudentService service)
        {
            context = service;
        }
        public Student Student { get; set; }
        public IActionResult OnGet(int sid)
        {

            Student = context.GetStudent(sid);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}