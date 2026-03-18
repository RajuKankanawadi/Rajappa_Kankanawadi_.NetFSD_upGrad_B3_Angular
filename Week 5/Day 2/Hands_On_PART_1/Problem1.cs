using System;

namespace StudentRecordArray

    // Problem 1: Student Record Management System Using Record Data Structure 
{
    // Record 
    public record Student(int RollNumber, string Name, string Course, int Marks);

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = ReadValidInt();

            Student[] students = new Student[n];

           
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");

                Console.Write("Enter Roll Number: ");
                int roll = ReadValidInt();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                int marks = ReadValidMarks();

                students[i] = new Student(roll, name, course, marks);
            }

            // Menu
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                int choice = ReadValidInt();

                switch (choice)
                {
                    case 1:
                        DisplayStudents(students);
                        break;

                    case 2:
                        Console.Write("Enter Roll Number to search: ");
                        int searchRoll = ReadValidInt();
                        SearchStudent(students, searchRoll);
                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // Display Student Method
        static void DisplayStudents(Student[] students)
        {
            Console.WriteLine("\nStudent Records:");

            foreach (Student s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // Search Student Method
        static void SearchStudent(Student[] students, int roll)
        {
            bool found = false;

            foreach (Student s in students)
            {
                if (s.RollNumber == roll)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nStudent not found!");
            }
        }

        // Validate roll number
        static int ReadValidInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Invalid input! Enter positive number: ");
            }
            return value;
        }

        // Validate marks
        static int ReadValidMarks()
        {
            int marks;
            while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
            {
                Console.Write("Invalid marks! Enter (0-100): ");
            }
            return marks;
        }
    }
}