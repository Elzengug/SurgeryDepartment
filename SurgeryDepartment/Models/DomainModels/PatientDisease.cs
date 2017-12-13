using System.Collections.Generic;

namespace SurgeryDepartment.Models.DomainModels
{
    public class PatientDisease
    {   public int Prise { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public Disease Disease { get; set; }
        public int DiseaseId { get; set; }

        public ICollection<Treatment> Treatments { get; set; }
    }
}