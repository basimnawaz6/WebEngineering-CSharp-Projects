using HospitalManagementSystem.DAL;
using HospitalManagementSystem.DTO;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HospitalManagementSystem.BLL
{
    public class PatientBLL
    {
        private readonly IPatientDAL _repo = new PatientDAL();

        public void AddPatient(PatientDTO patient)
        {
            _repo.Add(patient);
            LogToFile(patient, "Added:");
        }

        public void DeletePatient(string cnic)
        {
            var patient = _repo.GetByCNIC(cnic);
            _repo.Delete(cnic);
            LogToFile(patient, "Deleted:");
        }

        public void UpdatePatient(PatientDTO patient)
        {
            _repo.Update(patient);
        }

        public List<PatientDTO> GetAllPatients() => _repo.GetAll();

        public PatientDTO GetPatientByCNIC(string cnic) => _repo.GetByCNIC(cnic);

        private void LogToFile(PatientDTO patient, string prefix)
        {
            var json = JsonSerializer.Serialize(patient);
            File.AppendAllText("Patient.txt", $"{prefix} {json}{Environment.NewLine}");
        }
    }
}