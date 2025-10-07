using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DTO
{
    [Serializable]
    public class PatientDTO
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public List<int> Appointments { get; set; } = new List<int>();

        public PatientDTO() { }

        public PatientDTO(string name, string cnic)
        {
            Name = name;
            CNIC = cnic;
        }

        public bool HasAppointment(int appointmentID)
        {
            return Appointments.Contains(appointmentID);
        }

        public override string ToString()
        {
            return $"Patient Name: {Name}, CNIC: {CNIC}";
        }
    }
}