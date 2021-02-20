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
        public  void OnGet()
        {
        }
        [BindProperty]
        public Student Student { get; set; }
        IStudentService studentService;
        public CreateModel(IStudentService service)
        {
            this.studentService = service;
        }
        public IActionResult  OnPostAsync()
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