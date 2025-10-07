using HospitalManagementSystem.DTO;
using System.Collections.Generic;

namespace HospitalManagementSystem.BLL
{
    public class Hospital
    {
        public List<DoctorDTO> Doctors { get; } = new List<DoctorDTO>();
        public List<PatientDTO> Patients { get; } = new List<PatientDTO>();
        public List<AppointmentDTO> Appointments { get; } = new List<AppointmentDTO>();

        private readonly DoctorBLL _doctorService = new DoctorBLL();
        private readonly PatientBLL _patientService = new PatientBLL();
        private readonly AppointmentBLL _appointmentService = new AppointmentBLL();

        public void LoadData()
        {
            Doctors.Clear();
            Patients.Clear();
            Appointments.Clear();

            Doctors.AddRange(_doctorService.GetAllDoctors());
            Patients.AddRange(_patientService.GetAllPatients());
            Appointments.AddRange(_appointmentService.GetAllAppointments());
        }

        public void AddDoctor(DoctorDTO doctor) => _doctorService.AddDoctor(doctor);
        public void DeleteDoctor(int id) => _doctorService.DeleteDoctor(id);
        public void UpdateDoctor(DoctorDTO doctor) => _doctorService.UpdateDoctor(doctor);

        public void AddPatient(PatientDTO patient) => _patientService.AddPatient(patient);

        public void UpdatePatient(PatientDTO updatedPatient)
        {
            if (updatedPatient == null || string.IsNullOrWhiteSpace(updatedPatient.CNIC))
                return;
            _patientService.UpdatePatient(updatedPatient);

            var existing = Patients.FirstOrDefault(p => p.CNIC == updatedPatient.CNIC);
            if (existing != null)
            {
                existing.Name = updatedPatient.Name;
            }
            LoadData();
        }

        public void DeletePatient(string cnic) => _patientService.DeletePatient(cnic);
        public PatientDTO GetPatient(string cnic) => _patientService.GetPatientByCNIC(cnic);

        public void BookAppointment(AppointmentDTO appt) => _appointmentService.BookAppointment(appt);
        public void CancelAppointment(int id) => _appointmentService.CancelAppointment(id);

        public DoctorDTO GetDoctorById(int id) => Doctors.Find(d => d.DoctorID == id);
    }
}