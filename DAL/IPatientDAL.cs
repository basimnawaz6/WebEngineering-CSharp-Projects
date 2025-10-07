using HospitalManagementSystem.DTO;
using System.Collections.Generic;

namespace HospitalManagementSystem.DAL
{
    public interface IPatientDAL
    {
        void Add(PatientDTO patient);
        void Update(PatientDTO patient);
        void Delete(string cnic);
        List<PatientDTO> GetAll();
        PatientDTO GetByCNIC(string cnic);
    }
}