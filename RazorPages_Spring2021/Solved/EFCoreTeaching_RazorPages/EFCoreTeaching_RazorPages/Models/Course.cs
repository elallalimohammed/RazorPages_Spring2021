using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Models
{
  public class Course
	{
        [Display(Name = "Code")]
        public int CourseId { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CourseName { get; set; }

        [Range(0, 7)]
        public int Credits { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    }  

}
