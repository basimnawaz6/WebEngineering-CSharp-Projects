using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace HospitalManagementSystem.DAL
{
    public class PatientDAL : IPatientDAL
    {
        private readonly string _connectionString =
    @"Server=(localdb)\MSSQLLocalDB;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true;";
        public void Add(PatientDTO patient)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Patient (Name, CNIC) VALUES (@name, @cnic)", conn);
            cmd.Parameters.AddWithValue("@name", patient.Name);
            cmd.Parameters.AddWithValue("@cnic", patient.CNIC);
            cmd.ExecuteNonQuery();
        }

        public void Update(PatientDTO patient)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "UPDATE Patient SET Name = @name WHERE CNIC = @cnic", conn);
            cmd.Parameters.AddWithValue("@name", patient.Name);
            cmd.Parameters.AddWithValue("@cnic", patient.CNIC);
            cmd.ExecuteNonQuery();
        }

        public void Delete(string cnic)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Patient WHERE CNIC = @cnic", conn);
            cmd.Parameters.AddWithValue("@cnic", cnic);
            cmd.ExecuteNonQuery();
        }

        public List<PatientDTO> GetAll()
        {
            var list = new List<PatientDTO>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Name, CNIC FROM Patient", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PatientDTO
                {
                    Name = reader.GetString("Name"),
                    CNIC = reader.GetString("CNIC")
                });
            }
            return list;
        }

        public PatientDTO GetByCNIC(string cnic)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Name, CNIC FROM Patient WHERE CNIC = @cnic", conn);
            cmd.Parameters.AddWithValue("@cnic", cnic);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new PatientDTO
                {
                    Name = reader.GetString("Name"),
                    CNIC = reader.GetString("CNIC")
                };
            }
            return null;
        }
    }
}