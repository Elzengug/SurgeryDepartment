﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SurgeryDepartment.Interfaces.Services.Base;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Interfaces.Services
{
    public interface IPatientDiseaseService : IGenericService<PatientDisease>
    {
        //    Task<ICollection<PatientDisease>> GetPrice(int patientId, int tretmentId);

    }
}