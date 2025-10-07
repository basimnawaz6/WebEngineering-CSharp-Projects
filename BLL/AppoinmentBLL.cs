using HospitalManagementSystem.DAL;
using HospitalManagementSystem.DTO;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HospitalManagementSystem.BLL
{
    public class AppointmentBLL
    {
        private readonly IAppointmentDAL _repo = new AppointmentDAL();

        public void BookAppointment(AppointmentDTO appointment)
        {
            _repo.Add(appointment);
            LogToFile(appointment, "Added:");
        }

        public void CancelAppointment(int appointmentID)
        {
            var appt = _repo.GetById(appointmentID);
            _repo.Delete(appointmentID);
            LogToFile(appt, "Deleted:");
        }

        public List<AppointmentDTO> GetAllAppointments() => _repo.GetAll();

        private void LogToFile(AppointmentDTO appt, string prefix)
        {
            var json = JsonSerializer.Serialize(appt);
            File.AppendAllText("Appointment.txt", $"{prefix} {json}{Environment.NewLine}");
        }
    }
}