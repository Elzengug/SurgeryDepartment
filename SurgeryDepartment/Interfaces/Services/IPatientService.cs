using System;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services.Base;
using SurgeryDepartment.Models.DomainModels;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SurgeryDepartment.Interfaces.Services
{
    public interface IPatientService : IGenericService<Patient>
    {
        Task<ICollection<Patient>> GetFiltredPatient(DateTime date);
        Task<ICollection<Patient>> GetFiltredPatient(string desease);
        
    }
}