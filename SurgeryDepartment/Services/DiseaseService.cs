﻿using System;
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
    public class DiseaseService : GenericService<Disease> , IDiseaseService
    {
        public DiseaseService(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}