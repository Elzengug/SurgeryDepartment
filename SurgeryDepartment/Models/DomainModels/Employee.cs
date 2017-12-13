using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurgeryDepartment.Models.DomainModels
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Post { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Shedule { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
    }
}