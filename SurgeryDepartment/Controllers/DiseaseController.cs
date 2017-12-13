using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }
        // GET: Disease
        public async Task<ActionResult> CreateDisease(Disease disease)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.disease = "Not Valid";
            }
            try
            {
                await _diseaseService.AddAsync(disease);
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