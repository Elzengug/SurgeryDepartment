using System.Collections.Generic;

namespace SurgeryDepartment.Models.DomainModels
{
    public class Room
    {
        public int Id { get; set; }
        public int MaxCapacity { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}