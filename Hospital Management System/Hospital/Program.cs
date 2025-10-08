using HospitalManagementSystem.BLL;
using HospitalManagementSystem.PL;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main()
        {
            var system = new Hospital();
            system.LoadData();

            var doctorPL = new DoctorPL(system);
            var patientPL = new PatientPL(system);
            var appointmentPL = new AppointmentPL(system);

            while (true)
            {
                Console.WriteLine("\n=== Hospital Management System ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. Display All Patients");
                Console.WriteLine("5. Add Doctor");
                Console.WriteLine("6. Update Doctor");
                Console.WriteLine("7. Delete Doctor");
                Console.WriteLine("8. Display All Doctors");
                Console.WriteLine("9. Book Appointment");
                Console.WriteLine("10. Cancel Appointment");
                Console.WriteLine("11. Declare Most Consulted Doctor");
                Console.WriteLine("12. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Patient Name: ");
                        string pName = Console.ReadLine();
                        Console.Write("Enter CNIC: ");
                        string cnic = Console.ReadLine();
                        patientPL.AddPatient(pName, cnic);
                        break;

                    case "2":
                        Console.Write("Enter CNIC to update: ");
                        string uCnic = Console.ReadLine();
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        patientPL.UpdatePatient(uCnic, newName);
                        break;

                    case "3":
                        Console.Write("Enter CNIC to delete: ");
                        string dCnic = Console.ReadLine();
                        patientPL.DeletePatient(dCnic);
                        break;

                    case "4":
                        patientPL.DisplayAllPatients();
                        break;

                    case "5":
                        Console.Write("Enter Doctor Name: ");
                        string dName = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string spec = Console.ReadLine();
                        doctorPL.AddDoctor(dName, spec);
                        break;

                    case "6":
                        Console.Write("Enter Doctor ID: ");
                        int did = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newDName = Console.ReadLine();
                        Console.Write("Enter New Specialization: ");
                        string newSpec = Console.ReadLine();
                        doctorPL.UpdateDoctor(did, newDName, newSpec);
                        break;

                    case "7":
                        Console.Write("Enter Doctor ID to delete: ");
                        int delDid = int.Parse(Console.ReadLine());
                        doctorPL.DeleteDoctor(delDid);
                        break;

                    case "8":
                        doctorPL.DisplayAllDoctors();
                        break;

                    case "9":
                        Console.Write("Enter Doctor ID: ");
                        int docId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Patient CNIC: ");
                        string patCnic = Console.ReadLine();
                        Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        bool success = appointmentPL.BookAppointment(docId, patCnic, date);
                        Console.WriteLine(success ? "Appointment booked successfully." : "Failed: Doctor unavailable or invalid data.");
                        break;

                    case "10":
                        Console.Write("Enter Appointment ID: ");
                        int apptId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Patient CNIC: ");
                        string cancelCnic = Console.ReadLine();
                        appointmentPL.CancelAppointment(apptId, cancelCnic);
                        break;

                    case "11":
                        appointmentPL.DeclareMostConsultedDoctor();
                        break;

                    case "12":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}