using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.employee = "Not Valid";

            }
            try
            {
                await _employeeService.AddAsync(employee);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View();
        }
        
    }
}