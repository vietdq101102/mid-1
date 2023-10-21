using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        TestStudent testStudent = new TestStudent();
        testStudent.Run();
    }
}
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string DateOfBirth { get; set; }
    public string Class { get; set; }
    public float Mark1 { get; set; }
    public float Mark2 { get; set; }
    public float Mark3 { get; set; }

    public float MarkAVG()
    {
        return (Mark1 + Mark2 + Mark3) / 3;
    }
}
class TestStudent
{
    private List<Student> students;
    public TestStudent()
    {
        students = new List<Student>();
    }
    public void InputInformation()
    {
        Student student = new Student();
        Console.WriteLine("Enter student information:");
        Console.WriteLine("ID: ");
        student.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Name: ");
        student.Name = Console.ReadLine();
        Console.WriteLine("Gender: ");
        student.Gender = Console.ReadLine();
        Console.WriteLine("Age: ");
        student.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Date Of Birth: ");
        student.DateOfBirth = Console.ReadLine();
        Console.WriteLine("Class: ");
        student.Class = Console.ReadLine();
        Console.WriteLine("Mark 1: ");
        student.Mark1 = float.Parse(Console.ReadLine());
        Console.WriteLine("Mark 2: ");
        student.Mark2 = float.Parse(Console.ReadLine());
        Console.WriteLine("Mark 3: ");
        student.Mark3 = float.Parse(Console.ReadLine());
        students.Add(student);
        Console.WriteLine("Student added success!");
    }
    public void SearchStudentByName()
    {
        Console.WriteLine("Enter student name: ");
        string name = Console.ReadLine();
        List<Student> foundStudents = students.FindAll(student => student.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (foundStudents.Count == 0)
        {
            Console.WriteLine("Student name not found!");
        }
        else
        {
            Console.WriteLine("Found student: ");
            foreach (Student student in foundStudents)
            {
                Console.WriteLine("ID: " + student.Id + ", Name: " + student.Name + ", Gender: " + student.Gender + ", Age: " + student.Age + ", Date Of Birth: " + student.DateOfBirth + ", Mark Avg: " + student.MarkAVG());
            }
        }
    }
    public void DeleteStudentByStudentID()
    {
        Console.WriteLine("Enter student ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());
        int index = students.FindIndex(student => student.Id == id);
        if (index == -1)
        {
            Console.WriteLine("Studen ID not found!");
        }
        else
        {
            students.RemoveAt(index);
            Console.WriteLine("Student deleted success!");
        }
    }
    public void DisplayAllTheStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No student available");
        }
        else
        {
            Console.WriteLine("All The Student: ");
            foreach (Student student in students)
            {
                Console.WriteLine("ID: " + student.Id + ", Name: " + student.Name + ", Gender: " + student.Gender + ", Age: " + student.Age + ", Date Of Birth: " + student.DateOfBirth + ", Mark Avg: " + student.MarkAVG());
            }
        }
    }
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Input Information (Input Details For A Student).");
            Console.WriteLine("2. Sorting Student Asccending By Average Mark.");
            Console.WriteLine("3. Display All The Student.");
            Console.WriteLine("4. Search Student By Name.");
            Console.WriteLine("5. Delete Student By Student Id.");
            Console.WriteLine("6. Exit Program.");

            Console.WriteLine("Enter your choice (1-6): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            switch (choice)
            {
                case 1: InputInformation();
                    break;
                case 2: SortingStudentAsccendingByAverageMark();
                    break;
                case 3: DisplayAllTheStudent();
                    break;
                case 4: SearchStudentByName();
                    break;
                case 5: DeleteStudentByStudentID();
                    break;
                case 6: Console.WriteLine("Exit Program.");
                    return;
                default: Console.WriteLine("Available choice! Please Try Again!");
                    break;
            }
            Console.WriteLine();
        }
    }
}