using System.Collections.Generic;

namespace SurgeryDepartment.Models.DomainModels
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PatientDisease> PatientDiseases { get; set; }
        
        public ICollection<DiseaseSymptom> DiseaseSymptoms { get; set; }
    }
}