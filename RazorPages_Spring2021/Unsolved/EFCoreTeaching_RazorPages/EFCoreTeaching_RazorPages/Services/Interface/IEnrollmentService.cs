using EFCoreTeaching_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.Interface
{
    public interface IEnrollmentService
    {
        IEnumerable<Enrollment> GetEnrollments();
    }
}
