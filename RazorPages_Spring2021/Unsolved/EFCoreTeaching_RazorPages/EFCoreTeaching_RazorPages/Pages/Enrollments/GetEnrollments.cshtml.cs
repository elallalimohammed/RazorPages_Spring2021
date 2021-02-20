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
    public class GetEnrollmentsModel : PageModel
    {
       public  IEnumerable<Enrollment> Enrollments { get; set; }
        IEnrollmentService context;
        public GetEnrollmentsModel(IEnrollmentService service)
        {
            context = service;
        }
        public void OnGet()
        {
            Enrollments = context.GetEnrollments();
        }
    }
}