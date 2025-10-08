using HospitalManagementSystem.BLL;
using HospitalManagementSystem.DTO;

namespace HospitalManagementSystem.PL
{
    public class PatientPL
    {
        private readonly Hospital _system;

        public PatientPL(Hospital system)
        {
            _system = system;
        }

        public void AddPatient(string name, string cnic)
        {
            var patient = new PatientDTO(name, cnic);
            _system.AddPatient(patient);
            _system.LoadData();
        }

        public void UpdatePatient(string cnic, string newName)
        {
            var patient = _system.GetPatient(cnic);
            if (patient != null)
            {
                patient.Name = newName;
                _system.UpdatePatient(patient);
                _system.LoadData();
            }
        }

        public void DeletePatient(string cnic)
        {
            _system.DeletePatient(cnic);
            _system.LoadData();
        }

        public void DisplayAllPatients()
        {
            foreach (var patient in _system.Patients)
            {
                Console.WriteLine(patient);
            }
        }
    }
}