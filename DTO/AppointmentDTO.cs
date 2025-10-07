using System;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DTO
{
    [Serializable]
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public string PatientCNIC { get; set; }
        public DateTime AppointmentDate { get; set; }

        public AppointmentDTO() { }

        public AppointmentDTO(int doctorID, string patientCNIC, DateTime date)
        {
            AppointmentID = new Random().Next(1000, 9999);
            DoctorID = doctorID;
            PatientCNIC = patientCNIC;
            AppointmentDate = date;
        }

        public override string ToString()
        {
            return $"Appointment ID: {AppointmentID}, Doctor ID: {DoctorID}, Patient CNIC: {PatientCNIC}, Date: {AppointmentDate:yyyy-MM-dd HH:mm}";
        }
    }
}