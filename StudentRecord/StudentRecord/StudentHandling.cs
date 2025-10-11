public class FileHandling
{

    private Student  S = new Student();

    public void CreateFile(string filename = "Student.txt")
    {

        if (!File.Exists(filename))
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(file);

            S.input();

            sw.WriteLine("ID\t\tName\t\tAge\t\tDept");
            sw.WriteLine($"{S.StudentId}\t\t{S.StudentName}\t\t{S.StudentAge}\t\t{S.StudentDepartment}");
            
            Console.WriteLine($"File Created Successfully");

            sw.Close();
            file.Close();
        }
        else
        {

            throw new ArgumentException($"File {filename} Already Exist!");

        }

    }


    public void ReadFile(string filename)
    {

        if (File.Exists(filename))
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(file);

            string? data = string.Empty;

            while ((data = sr.ReadLine()) != null)
            {

                Console.WriteLine(data);

            }

            Console.WriteLine("File Read Successfully");

            sr.Close();
            file.Close();

        }

        else
        {
            throw new ArgumentException($"File {filename} does not Exist!");


        }

    }


    public void AppendFile(string filename)
    {

        if (File.Exists(filename))
        {
            S.input();

            FileStream file = new FileStream(filename, FileMode.Append);
            StreamWriter sw = new StreamWriter(file);

            sw.WriteLine($"{S.StudentId}\t\t{S.StudentName}\t\t{S.StudentAge}\t\t{S.StudentDepartment}");
            Console.WriteLine("File Appended Successfully");


            sw.Close();
            file.Close();

        }

        else
        {

            Console.WriteLine($"File {filename} does not Exist! Create the File First");
            CreateFile(filename);

        }

    }
}