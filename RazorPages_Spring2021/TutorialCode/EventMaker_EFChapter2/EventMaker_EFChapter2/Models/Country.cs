﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EventMaker_EFChapter2.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Events = new HashSet<Event>();
        }
       
        [Key]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public double? PopulationNumber { get; set; }

        [InverseProperty(nameof(Event.CountryCodeNavigation))]
        public virtual ICollection<Event> Events { get; set; }
    }
}