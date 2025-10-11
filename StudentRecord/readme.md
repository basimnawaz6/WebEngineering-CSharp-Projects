# 📚 Student Record Management System

## 📖 Overview
The **Student Record Management System** is a C# console application that allows users to store, retrieve, and manage student records using file-based persistence.  
It demonstrates core C# concepts including **Object-Oriented Programming (OOP)**, **file I/O with FileStream**, and **menu-driven console interaction**.

Built as part of the *Web Technologies – SEF23 Homework 01* at PUCIT.

---

## 🧩 Features
- Add new student records (ID, Name, Age, Department)
- Save records to `students.txt` using `FileStream` in **append mode**
- Load and display all saved records using `FileStream` in **read mode**
- Clean, user-friendly console menu:
    - Add Student
    - View Students
    - Exit


---

## 🏗️ Project Structure


---

## 🛠️ Technologies Used
- **Language**: C# (.NET)
- **Core Concepts**:
  - Classes, Properties (get/set), Constructors
  - Object Initializer Syntax
  - FileStream with `FileMode.Append` and `FileMode.Open`
  - Text-based data serialization (`Id, Name, Age, Department`)

---

## ▶️ How to Run
1. Clone or download the repository
2. Open in Visual Studio or use `dotnet` CLI:
   ```bash
   dotnet run