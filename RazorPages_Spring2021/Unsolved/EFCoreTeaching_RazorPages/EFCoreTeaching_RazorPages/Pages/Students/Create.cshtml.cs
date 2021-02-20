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
    public class CreateModel : PageModel
    {    
        [BindProperty]
        public Student Student { get; set; }
        private IStudentService  studentService;
        public CreateModel(IStudentService service)
        {
            studentService= service;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            studentService.AddStudent(Student);
            return RedirectToPage("GetStudents");           
        }
    }
}