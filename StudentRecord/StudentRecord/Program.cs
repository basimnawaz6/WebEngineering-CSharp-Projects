using System;

namespace StudentRecord
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileHandling fh = new FileHandling();
            string filename = "Student.txt";

            while (true)
            {
                ShowMenu();

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        fh.AppendFile(filename);
                        break;

                    case 2:
                        try
                        {
                            fh.ReadFile(filename);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("//////// Choose Menu ////////");
            Console.WriteLine("1. Add new Student Data");
            Console.WriteLine("2. View all Student Data");
            Console.WriteLine("3. Exit the Program");
        }
    }
}
