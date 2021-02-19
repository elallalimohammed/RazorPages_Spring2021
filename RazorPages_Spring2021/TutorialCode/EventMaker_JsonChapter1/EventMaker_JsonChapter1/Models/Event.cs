using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMaker_JsonChapter1.Models
{ 
   public class Event
    {
        public int Id { get; set; }   
        public string Name { get; set; }  
        public string Description { get; set; }    
        public string City { get; set; }      
        public DateTime DateTime { get; set; }
         public string CountryCode { get; set; }
    }
}
