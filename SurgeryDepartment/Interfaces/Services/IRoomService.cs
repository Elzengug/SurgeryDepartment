using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services.Base;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Interfaces.Services
{
    public interface IRoomService : IGenericService<Room>
    {
        Task<ICollection<Patient>> GetPatientInRoom(int number);
    }
}