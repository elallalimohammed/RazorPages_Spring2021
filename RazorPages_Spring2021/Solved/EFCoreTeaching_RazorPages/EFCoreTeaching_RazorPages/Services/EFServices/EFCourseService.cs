using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.EFServices
{
    public class EFCourseService:ICourseService
    {
        RegistrationDBContext context;
        public EFCourseService(RegistrationDBContext service)
        {
            context = service;
        }
        public IEnumerable<Course> GetCourses()
        {
            return context.Courses;
        }
        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }
        public Course GetCourse(int id)
        {
         var course= context.Courses
        .Include(s => s.Enrollments).ThenInclude(n=>n.Student)
        .AsNoTracking()
        .FirstOrDefault(m => m.CourseId == id);
         return course;
        }
    }
}
