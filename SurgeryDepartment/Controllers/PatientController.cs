using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;
using SurgeryDepartment.Models.ViewModels;

namespace SurgeryDepartment.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            PatientViewModel patientViewModel = new PatientViewModel
            {
                Patients = await _patientService.FindAllAsync(u => true)
            };
            return View(patientViewModel);
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.patient = "Not Valid";

            }
            try
            {
                await _patientService.AddAsync(patient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> InsertPatientInRoom(int roomId, int userId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.patient = "Not Valid";

            }
            try
            {
                var user = await _patientService.FindFirstAsync(u => u.CardNumber == userId);
                user.Room.Id = roomId;
                await _patientService.UpdateAsync(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(Patient patient)
        {
            try
            {
                await _patientService.UpdateAsync(patient);
            }
            catch (ArgumentNullException)
            {
                return Content("Такого пациента не существует");
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int patientId)
        {
            try
            {
                var patient = await _patientService.FindFirstAsync(p => p.CardNumber == patientId);
                await _patientService.RemoveAsync(patient);
            }
            catch (ArgumentNullException)
            {
                return Content("Такого пациента не существует");
            }
            return RedirectToAction("Index");
        }
    }
}