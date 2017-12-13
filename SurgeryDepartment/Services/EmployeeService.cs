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
    public class EmployeeService : GenericService<Employee>, IEmployeeService
    {
        private readonly IRoomService _roomService;
        public EmployeeService(IDbContext dbContext, IRoomService roomService) : base(dbContext)
        {
            _roomService = roomService;
        }

        public async Task<ICollection<Employee>> GetFiltredEmployeeByPost(string post)
        {
            return await DetachedQueryable.Where(u => u.Post == post).ToListAsync();
        }

        public async Task<ICollection<Employee>> GetFiltredEmployeeByShedule(string shedule)
        {
            return await DetachedQueryable.Where(u => u.Shedule == shedule).ToListAsync();
        }

       
    }
}