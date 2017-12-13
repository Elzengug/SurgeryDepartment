using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;
using SurgeryDepartment.Models.EF;
using SurgeryDepartment.Services.Base;

namespace SurgeryDepartment.Services
{
    public class PatientDiseaseService : GenericService<PatientDisease>, IPatientDiseaseService
    {
        public PatientDiseaseService(IDbContext dbContext) : base(dbContext)
        {

        }

        //public async Task<ICollection<PatientDisease>> GetPrice(int patientId, int tretmentId)
        //{
           
        //    return await  ;
        //}
    }
}