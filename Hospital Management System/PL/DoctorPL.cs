using HospitalManagementSystem.BLL;
using HospitalManagementSystem.DTO;

namespace HospitalManagementSystem.PL
{
    public class DoctorPL
    {
        private readonly Hospital _system;

        public DoctorPL(Hospital system)
        {
            _system = system;
        }

        public void AddDoctor(string name, string specialization)
        {
            var doctor = new DoctorDTO(name, specialization);
            _system.AddDoctor(doctor);
            _system.LoadData();
        }

        public void UpdateDoctor(int doctorID, string newName, string newSpecialization)
        {
            var doctor = _system.GetDoctorById(doctorID);
            if (doctor != null)
            {
                doctor.Name = newName;
                doctor.Specialization = newSpecialization;
                _system.UpdateDoctor(doctor);
                _system.LoadData();
            }
        }

        public void DeleteDoctor(int doctorID)
        {
            _system.DeleteDoctor(doctorID);
            _system.LoadData();
        }

        public void DisplayAllDoctors()
        {
            foreach (var doctor in _system.Doctors)
            {
                Console.WriteLine(doctor);
            }
        }
    }
}