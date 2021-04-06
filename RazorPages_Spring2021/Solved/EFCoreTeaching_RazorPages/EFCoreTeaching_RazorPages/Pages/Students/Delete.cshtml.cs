using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Sale_EFChapter3.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        
        IStudentService studentService;
       
        public DeleteModel(IStudentService service)
        {
            this.studentService = service;
            Student = new Student();
        }
        public void OnGet(int id)
        {     
               Student = studentService.GetStudent(id);       
        }
        public IActionResult  OnPost()
        {
           studentService.DeleteStudent(Student);

            return RedirectToPage("GetStudents");
        }
    }
}