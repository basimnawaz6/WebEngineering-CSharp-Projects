using HospitalManagementSystem.DAL;
using HospitalManagementSystem.DTO;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HospitalManagementSystem.BLL
{
    public class DoctorBLL
    {
        private readonly IDoctorDAL _repo = new DoctorDAL();

        public void AddDoctor(DoctorDTO doctor)
        {
            _repo.Add(doctor);
            LogToFile(doctor, "Added:");
        }

        public void DeleteDoctor(int doctorID)
        {
            var doctor = _repo.GetById(doctorID);
            _repo.Delete(doctorID);
            LogToFile(doctor, "Deleted:");
        }

        public void UpdateDoctor(DoctorDTO doctor)
        {
            _repo.Update(doctor);
        }

        public List<DoctorDTO> GetAllDoctors() => _repo.GetAll();

        private void LogToFile(DoctorDTO doctor, string prefix)
        {
            var json = JsonSerializer.Serialize(doctor);
            File.AppendAllText("Doctor.txt", $"{prefix} {json}{Environment.NewLine}");
        }
    }
}