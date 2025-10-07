using System;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DTO
{
    [Serializable]
    public class DoctorDTO
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }

        public DoctorDTO() { }

        public DoctorDTO(string name, string specialization)
        {
            DoctorID = GenerateDoctorID();
            Name = name;
            Specialization = specialization;
            IsAvailable = true;
        }

        private int GenerateDoctorID()
        {
            return new Random().Next(10000, 99999);
        }

        public void MarkUnavailable() => IsAvailable = false;
        public void MarkAvailable() => IsAvailable = true;

        public override string ToString()
        {
            string status = IsAvailable ? "Available" : "Not Available";
            return $"Doctor ID: {DoctorID}, Name: {Name}, Specialization: {Specialization}, Status: {status}";
        }
    }
}