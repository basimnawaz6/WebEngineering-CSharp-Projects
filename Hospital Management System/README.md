# 🏥 Hospital Management System

## 📖 Overview
The **Hospital Management System (HMS)** is a C# .NET application that manages **patients**, **doctors**, and **appointments** efficiently.  
It is built using a **four-tier architecture** for clean separation of concerns, making it easy to maintain, extend, and debug.

---

## 🧩 Architecture
The system follows a **4-tier architecture**:

1. **Data Transfer Objects (DTO):**  
   Contains simple classes (`DoctorDTO`, `PatientDTO`, `AppointmentDTO`) that define data structures passed between layers.

2. **Data Access Layer (DAL):**  
   Handles all database-related operations such as insert, update, delete, and retrieval using **Microsoft.Data.SqlClient**.  
   Example files:  
   - `DoctorDAL.cs`  
   - `PatientDAL.cs`  
   - `AppointmentDAL.cs`

3. **Business Logic Layer (BLL):**  
   Contains business logic and validation rules. It processes input from the Presentation Layer and interacts with the DAL.  
   Example files:  
   - `DoctorBLL.cs`  
   - `PatientBLL.cs`  
   - `AppointmentBLL.cs`

4. **Presentation Layer (PL):**  
   Acts as the **user interface** for the system, implemented as a **console application**.  
   It interacts directly with the BLL to perform operations.  
   Example files:  
   - `DoctorPL.cs`  
   - `PatientPL.cs`  
   - `AppointmentPL.cs`

---
## 🏗️ Project Structure

Hospital/
    DTO/
        DoctorDTO.cs
        PatientDTO.cs
        AppointmentDTO.cs

    DAL/
        IDoctorDAL.cs
        IPatientDAL.cs
        IAppointmentDAL.cs
        DoctorDAL.cs
        PatientDAL.cs
        AppointmentDAL.cs

    BLL/
        DoctorBLL.cs
        PatientBLL.cs
        AppointmentBLL.cs
        Hospital.cs

    PL/
        DoctorPL.cs
        PatientPL.cs
        AppointmentPL.cs

    Hospital/
        Program.cs
