namespace SurgeryDepartment.Models.DomainModels
{
    public class DiseaseSymptom
    {
        public Disease Disease { get; set; }
        public int DiseaseId { get; set; }

        public Symptom Symptom { get; set; }
        public int SymptomId { get; set; }
    }
}