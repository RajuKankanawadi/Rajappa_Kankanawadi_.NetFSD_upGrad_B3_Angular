using System;

class StudentProblem
{
    public static void Run()
    {
        Student s = new Student();

        Console.Write("Enter Marks 1: ");
        int m1 = int.Parse(Console.ReadLine());

        Console.Write("Enter Marks 2: ");
        int m2 = int.Parse(Console.ReadLine());

        Console.Write("Enter Marks 3: ");
        int m3 = int.Parse(Console.ReadLine());

        double avg = s.CalculateAverage(m1, m2, m3);

        string grade;

        if (avg >= 80)
            grade = "A";
        else if (avg >= 60)
            grade = "B";
        else if (avg >= 40)
            grade = "C";
        else
            grade = "Fail";

        Console.WriteLine("Average = " + avg);
        Console.WriteLine("Grade = " + grade);
        Console.WriteLine();
    }
}

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }
}

class Program
{
    static void Main()
    { 
        StudentProblem.Run();

        Console.ReadLine();
    }
}

