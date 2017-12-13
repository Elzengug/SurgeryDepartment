using System.Collections.Generic;

namespace SurgeryDepartment.Models.DomainModels
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DiseaseSymptom> DiseaseSymptoms{ get; set; }
    }
}