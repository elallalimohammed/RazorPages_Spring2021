using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    [Table("Actor")]
    public partial class Actor
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public DateTime Birth_year { get; set; }

        [Required]
        public bool Alive { get; set; }
    }
}
