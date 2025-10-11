using System;
using System.IO;

public class Student
{
    private int id;
    private string name;
    private int age;
    private string department;

    public Student()
    {
        id = 0;
        name = "Unknown";
        age = 0;
        department = "Unknown";
    }

    public Student(int id, string name, int age, string department)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.department = department;
    }

    //there is no need for geter and seter becasue i use input function to set value
    public int StudentId
    {
        get { return id; }
        set { id = value; }        
    }
    public string StudentName
    {
        get { return name; }
        set { name = value; }
    }

    public int StudentAge
    {
        get { return age; }
        set { age = value; }
    }

    public string StudentDepartment
    {
        get { return department; }
        set { department = value; }
    }

    public void input()
    {
        Console.WriteLine("Enter Student ID:");
        id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Student Name:");
        name = Console.ReadLine();

        Console.WriteLine("Enter Student Age:");
        age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Student Department:");
        department = Console.ReadLine();


    }

    public void display()
    {

        Console.WriteLine($"Student ID: {id}");

        Console.WriteLine($"Student Name: {name}");

        Console.WriteLine($"Student Age: {age}");

        Console.WriteLine($"Student Department: {department}");

    }

}