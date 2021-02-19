using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sale_EFChapter3.Models
{
   
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int? Age { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }

}
