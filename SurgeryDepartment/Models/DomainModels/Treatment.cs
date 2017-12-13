namespace SurgeryDepartment.Models.DomainModels
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public PatientDisease PatientDisease { get; set; }
        public int PatientDiseaseId { get; set; }
    }
}