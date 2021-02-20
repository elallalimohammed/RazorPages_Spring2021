using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace EFCoreMovie2_RazorPages.Models
{
    [Table("Movie")]
    public partial class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int Year { get; set; }
        public int RunningTimeInMins { get; set; }
        public int StudioId { get; set; }

        [ForeignKey(nameof(StudioId))]
        [InverseProperty("Movies")]
        public virtual Studio Studio { get; set; }
    }
}

