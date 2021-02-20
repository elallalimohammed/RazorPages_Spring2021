using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreTeaching_RazorPages.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        IEnrollmentService enrollService;
        public CreateModel(IEnrollmentService service)
        {
            this.enrollService = service;
        }
        public void OnGet(int sid , int cid)
        {         
            Enrollment.StudentId = sid;
           Enrollment.CourseId= cid;
        }
        [BindProperty]
        public Enrollment Enrollment { get; set; } = new Enrollment();        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           enrollService.AddEnrollment(Enrollment);
            
            return RedirectToPage("GetEnrollments");
        }
    }
}