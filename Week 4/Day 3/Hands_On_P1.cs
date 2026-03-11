
/* Probelm : 1-- You are developing a console-based application in .NET 8 for a school. 
 The application should evaluate a student’s marks and assign a grade based on predefined rules. */

using System;

class Problem1
{
    static void Main(string[] args)
    {
        // student name
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();

        // student marks
        Console.WriteLine("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid Marks! Please enter marks between 0 and 100.");
        }
        else
        {
            
            Console.WriteLine("\nStudent Details: ");
            Console.WriteLine("Student Name is : " + name);


            // if - else statement
            if (marks >= 80)
            {
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 50)
            {
                Console.WriteLine("Grade: C");
            }
            else if (marks >= 40)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}
