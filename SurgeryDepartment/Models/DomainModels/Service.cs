namespace SurgeryDepartment.Models.DomainModels
{
    public class Service
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}