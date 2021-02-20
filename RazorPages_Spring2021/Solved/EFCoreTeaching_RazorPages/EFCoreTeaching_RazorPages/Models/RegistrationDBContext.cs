using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Models
{
    public class RegistrationDBContext:DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder  options)
        {
            options.UseSqlServer (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistrationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments{ get; set; }
    }
}
