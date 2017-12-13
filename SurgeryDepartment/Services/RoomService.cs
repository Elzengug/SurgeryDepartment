using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;
using SurgeryDepartment.Models.EF;
using SurgeryDepartment.Services.Base;
namespace SurgeryDepartment.Services
{   
    public class RoomService : GenericService<Room>, IRoomService
    {
        public IPatientService _patientService;
        public RoomService(IDbContext dbContext, IPatientService patientService) : base(dbContext)
        {
            _patientService = patientService;
        }

        public async Task<ICollection<Patient>> GetPatientInRoom(int number)
        {
            return await _patientService.FindAllAsync(u => u.Room.Id == number);
        }
    }
}
