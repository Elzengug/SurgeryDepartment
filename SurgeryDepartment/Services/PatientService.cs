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
    public class PatientService : GenericService<Patient> , IPatientService
    {
        public PatientService(IDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<ICollection<Patient>> GetFiltredPatient(DateTime date)
        {
            return await DetachedQueryable.Where(u => u.EntryDate == date).ToListAsync();
        }

        public async Task<ICollection<Patient>> GetFiltredPatient(string desease)
        {
            return await DetachedQueryable.Where(u => u.Diagnosis == desease).ToListAsync();
        }
    }
}