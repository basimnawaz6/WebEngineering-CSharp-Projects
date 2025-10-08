using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace HospitalManagementSystem.DAL
{
    public class DoctorDAL : IDoctorDAL
    {
        private readonly string _connectionString =
    @"Server=(localdb)\MSSQLLocalDB;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true;";
        public void Add(DoctorDTO doctor)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Doctor (DoctorID, Name, Specialization, IsAvailable) VALUES (@id, @name, @spec, @avail)", conn);
            cmd.Parameters.AddWithValue("@id", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@name", doctor.Name);
            cmd.Parameters.AddWithValue("@spec", doctor.Specialization);
            cmd.Parameters.AddWithValue("@avail", doctor.IsAvailable);
            cmd.ExecuteNonQuery();
        }

        public void Update(DoctorDTO doctor)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "UPDATE Doctor SET Name=@name, Specialization=@spec, IsAvailable=@avail WHERE DoctorID=@id", conn);
            cmd.Parameters.AddWithValue("@id", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@name", doctor.Name);
            cmd.Parameters.AddWithValue("@spec", doctor.Specialization);
            cmd.Parameters.AddWithValue("@avail", doctor.IsAvailable);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int doctorID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Doctor WHERE DoctorID=@id", conn);
            cmd.Parameters.AddWithValue("@id", doctorID);
            cmd.ExecuteNonQuery();
        }

        public List<DoctorDTO> GetAll()
        {
            var list = new List<DoctorDTO>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT DoctorID, Name, Specialization, IsAvailable FROM Doctor", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DoctorDTO
                {
                    DoctorID = reader.GetInt32("DoctorID"),
                    Name = reader.GetString("Name"),
                    Specialization = reader.GetString("Specialization"),
                    IsAvailable = reader.GetBoolean("IsAvailable")
                });
            }
            return list;
        }

        public DoctorDTO GetById(int doctorID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT DoctorID, Name, Specialization, IsAvailable FROM Doctor WHERE DoctorID=@id", conn);
            cmd.Parameters.AddWithValue("@id", doctorID);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new DoctorDTO
                {
                    DoctorID = reader.GetInt32("DoctorID"),
                    Name = reader.GetString("Name"),
                    Specialization = reader.GetString("Specialization"),
                    IsAvailable = reader.GetBoolean("IsAvailable")
                };
            }
            return null;
        }
    }
}