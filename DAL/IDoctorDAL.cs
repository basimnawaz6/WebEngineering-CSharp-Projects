using HospitalManagementSystem.DTO;
using System.Collections.Generic;

namespace HospitalManagementSystem.DAL
{
    public interface IDoctorDAL
    {
        void Add(DoctorDTO doctor);
        void Update(DoctorDTO doctor);
        void Delete(int doctorID);
        List<DoctorDTO> GetAll();
        DoctorDTO GetById(int doctorID);
    }
}