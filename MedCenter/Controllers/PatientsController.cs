using MedCenter.Models;
using MedCenter.Storage;
using MedCenter.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MedCenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientStore _patientStore;

        public PatientsController(PatientStore patientStore)
        { 
            _patientStore = patientStore;
        }

        [HttpPost]
        public ActionResult<PatientResponse> CreatePatient(CreatePatientRequest request)
        {
            var patient = new Patient(request.Name, request.SeName, request.BirthDay);
            _patientStore.CreatePatient(patient);

            var newPatient = new PatientResponse();
            newPatient.Id= patient.Id;
            newPatient.Name = patient.Name;
            newPatient.SeName = patient.SeName;
            newPatient.BirthDay = patient.BirthDay;

            return Created($"/patients/{newPatient.Id}", newPatient);
        }
    }
}
