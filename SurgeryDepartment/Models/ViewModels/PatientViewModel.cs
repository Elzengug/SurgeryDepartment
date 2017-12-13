using System.Collections.Generic;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Models.ViewModels
{
    public class PatientViewModel
    {
        public ICollection<Patient> Patients { get; set; }
    }
}