using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.EFServices
{
    public class EFEnrollmentService:IEnrollmentService
    {
        RegistrationDBContext context;
        public EFEnrollmentService(RegistrationDBContext service)
        {
            context = service;
        }
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return context.Enrollments.Include(s=>s.Student).Include(c=>c.Course);
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
        }
    }
}
