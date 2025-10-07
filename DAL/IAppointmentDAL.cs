using HospitalManagementSystem.DTO;
using System.Collections.Generic;

namespace HospitalManagementSystem.DAL
{
    public interface IAppointmentDAL
    {
        void Add(AppointmentDTO appointment);
        void Delete(int appointmentID);
        List<AppointmentDTO> GetAll();
        AppointmentDTO GetById(int appointmentID);
        List<AppointmentDTO> GetByDoctor(int doctorID);
        List<AppointmentDTO> GetByPatient(string cnic);
    }
}