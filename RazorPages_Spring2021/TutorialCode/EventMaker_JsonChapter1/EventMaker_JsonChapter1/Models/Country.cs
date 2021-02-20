using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Models
{
    public  class Country
    {     
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public double? PopulationNumber { get; set; }
    }
}
