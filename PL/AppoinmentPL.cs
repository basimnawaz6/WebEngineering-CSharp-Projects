using HospitalManagementSystem.BLL;
using HospitalManagementSystem.DTO;

namespace HospitalManagementSystem.PL
{
    public class AppointmentPL
    {
        private readonly Hospital _system;

        public AppointmentPL(Hospital system)
        {
            _system = system;
        }

        public bool BookAppointment(int doctorID, string patientCNIC, DateTime appointmentDate)
        {
            var doctor = _system.GetDoctorById(doctorID);
            var patient = _system.GetPatient(patientCNIC);

            if (doctor == null || patient == null)
                return false;

            if (!doctor.IsAvailable)
                return false;

            // Mark doctor as unavailable after booking
            doctor.MarkUnavailable();
            _system.UpdateDoctor(doctor);

            var appointment = new AppointmentDTO(doctorID, patientCNIC, appointmentDate);
            _system.BookAppointment(appointment);
            _system.LoadData();

            // Add appointment ID to patient's list (simulate update)
            patient.Appointments.Add(appointment.AppointmentID);
            _system.UpdatePatient(patient);

            return true;
        }

        public void CancelAppointment(int appointmentID, string patientCNIC)
        {
            var appointment = _system.Appointments.Find(a => a.AppointmentID == appointmentID && a.PatientCNIC == patientCNIC);
            if (appointment != null)
            {
                // Free the doctor
                var doctor = _system.GetDoctorById(appointment.DoctorID);
                if (doctor != null)
                {
                    doctor.MarkAvailable();
                    _system.UpdateDoctor(doctor);
                }

                _system.CancelAppointment(appointmentID);
                _system.LoadData();

                // Remove from patient
                var patient = _system.GetPatient(patientCNIC);
                if (patient != null && patient.Appointments.Contains(appointmentID))
                {
                    patient.Appointments.Remove(appointmentID);
                    _system.UpdatePatient(patient);
                }
            }
        }

        public void DisplayAllAppointments()
        {
            foreach (var appt in _system.Appointments)
            {
                Console.WriteLine(appt);
            }
        }

        public void DeclareMostConsultedDoctor()
        {
            if (_system.Appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            var doctorAppointmentCounts = new Dictionary<int, int>();
            foreach (var appt in _system.Appointments)
            {
                if (doctorAppointmentCounts.ContainsKey(appt.DoctorID))
                    doctorAppointmentCounts[appt.DoctorID]++;
                else
                    doctorAppointmentCounts[appt.DoctorID] = 1;
            }

            var mostConsultedID = doctorAppointmentCounts.OrderByDescending(kvp => kvp.Value).First().Key;
            var mostConsulted = _system.GetDoctorById(mostConsultedID);
            Console.WriteLine($"Most Consulted Doctor: {mostConsulted?.Name} (ID: {mostConsultedID}) with {doctorAppointmentCounts[mostConsultedID]} appointments.");
        }
    }
}