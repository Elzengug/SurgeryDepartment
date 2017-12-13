using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services.Base;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Interfaces.Services
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        Task<ICollection<Employee>> GetFiltredEmployeeByPost(string post);
        Task<ICollection<Employee>> GetFiltredEmployeeByShedule(string shedule);
    }
}