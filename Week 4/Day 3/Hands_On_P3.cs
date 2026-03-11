/*  Problem--3  Develop a console application that calculates employee bonus
              based on salary and years of experience.*/

using System;

class Problem3
{
    static void Main(string[] args)
    {
        //  employee name
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        // salary
        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        // experience
        Console.Write("Enter Experience in Years: ");
        int exp = int.Parse(Console.ReadLine());

        double bonusRate;

        //  using if-else statement
        if (exp < 2)
        {
            bonusRate = 0.05;   
        }
        else if (exp >= 2 && exp <= 5)
        {
            bonusRate = 0.10;   
        }
        else
        {
            bonusRate = 0.15;   
        }

        // Calculate bonus
        double bonus = salary > 0 ? salary * bonusRate : 0;

        // Final salary
        double finalSalary = salary + bonus;

        // Display result
        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus);
        Console.WriteLine("Final Salary: " + finalSalary);
    }
}
