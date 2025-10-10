# 🏥 Hospital Management System

## 📖 Overview
The **Hospital Management System (HMS)** is a C# .NET application designed to simplify hospital operations by managing **patients**, **doctors**, and **appointments** effectively.  
It follows a **four-tier architecture** — separating **Presentation**, **Business Logic**, **Data Access**, and **Data Transfer** layers — for better maintainability, scalability, and testability.

---

## 🧩 Architecture
The system is built using the **Four-Tier Architecture** pattern:

1. **Presentation Layer (PL):**  
   This layer provides the **user interface** for the application.  
   Implemented as a **Console Application**, it handles user input/output and interacts with the Business Logic Layer.

2. **Business Logic Layer (BLL):**  
   Contains the **core logic** of the system, including data validation and hospital-related operations (e.g., managing doctors, patients, and appointments).

3. **Data Access Layer (DAL):**  
   Responsible for all database-related operations such as inserting, updating, deleting, and retrieving data using **Microsoft.Data.SqlClient**.

4. **Data Transfer Objects (DTO):**  
   Defines simple classes used to pass data between layers in a structured and type-safe manner.

---

## 🏗️ Project Structure
