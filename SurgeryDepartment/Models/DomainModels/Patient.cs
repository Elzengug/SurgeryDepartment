using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurgeryDepartment.Models.DomainModels
{
    public class Patient
    {
        [Key]
        public int CardNumber { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Diagnosis { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EntryDate { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }

        public ICollection<PatientDisease> PatientDiseases { get; set; }

    }
}