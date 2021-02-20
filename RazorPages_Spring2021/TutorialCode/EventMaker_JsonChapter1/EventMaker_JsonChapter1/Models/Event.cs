using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Models
{ 
   public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }  
        public string Description { get; set; }
       
        [Required]
        public string City { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }
         public string CountryCode { get; set; }
    }
}
