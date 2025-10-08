using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HospitalManagementSystem.DAL
{
    public class AppointmentDAL : IAppointmentDAL
    {
        private readonly string _connectionString =
    @"Server=(localdb)\MSSQLLocalDB;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true;";
        public void Add(AppointmentDTO appointment)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Appointment (AppointmentID, DoctorID, PatientCNIC, AppointmentDate) VALUES (@aid, @did, @cnic, @date)", conn);
            cmd.Parameters.AddWithValue("@aid", appointment.AppointmentID);
            cmd.Parameters.AddWithValue("@did", appointment.DoctorID);
            cmd.Parameters.AddWithValue("@cnic", appointment.PatientCNIC);
            cmd.Parameters.AddWithValue("@date", appointment.AppointmentDate);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int appointmentID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Appointment WHERE AppointmentID = @aid", conn);
            cmd.Parameters.AddWithValue("@aid", appointmentID);
            cmd.ExecuteNonQuery();
        }

        public List<AppointmentDTO> GetAll()
        {
            var list = new List<AppointmentDTO>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT AppointmentID, DoctorID, PatientCNIC, AppointmentDate FROM Appointment", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppointmentDTO
                {
                    AppointmentID = reader.GetInt32("AppointmentID"),
                    DoctorID = reader.GetInt32("DoctorID"),
                    PatientCNIC = reader.GetString("PatientCNIC"),
                    AppointmentDate = reader.GetDateTime("AppointmentDate")
                });
            }
            return list;
        }

        public AppointmentDTO GetById(int appointmentID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT AppointmentID, DoctorID, PatientCNIC, AppointmentDate FROM Appointment WHERE AppointmentID = @aid", conn);
            cmd.Parameters.AddWithValue("@aid", appointmentID);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new AppointmentDTO
                {
                    AppointmentID = reader.GetInt32("AppointmentID"),
                    DoctorID = reader.GetInt32("DoctorID"),
                    PatientCNIC = reader.GetString("PatientCNIC"),
                    AppointmentDate = reader.GetDateTime("AppointmentDate")
                };
            }
            return null;
        }

        public List<AppointmentDTO> GetByDoctor(int doctorID)
        {
            var list = new List<AppointmentDTO>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT AppointmentID, DoctorID, PatientCNIC, AppointmentDate FROM Appointment WHERE DoctorID = @did", conn);
            cmd.Parameters.AddWithValue("@did", doctorID);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppointmentDTO
                {
                    AppointmentID = reader.GetInt32("AppointmentID"),
                    DoctorID = reader.GetInt32("DoctorID"),
                    PatientCNIC = reader.GetString("PatientCNIC"),
                    AppointmentDate = reader.GetDateTime("AppointmentDate")
                });
            }
            return list;
        }

        public List<AppointmentDTO> GetByPatient(string cnic)
        {
            var list = new List<AppointmentDTO>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT AppointmentID, DoctorID, PatientCNIC, AppointmentDate FROM Appointment WHERE PatientCNIC = @cnic", conn);
            cmd.Parameters.AddWithValue("@cnic", cnic);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppointmentDTO
                {
                    AppointmentID = reader.GetInt32("AppointmentID"),
                    DoctorID = reader.GetInt32("DoctorID"),
                    PatientCNIC = reader.GetString("PatientCNIC"),
                    AppointmentDate = reader.GetDateTime("AppointmentDate")
                });
            }
            return list;
        }
    }
}