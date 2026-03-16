
using System;
using EmployeeProfie_Company_HR_System;

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee(101,"Rajappa", 25, 5000);
        Employee emp2 = new Employee(102, "Shiva", 26, 10000);

        Console.WriteLine("------Employee Profile 1 -------\n");
        Console.WriteLine("Employee ID: " + emp1.EmployeeId);
        Console.WriteLine("Employee Name: " + emp1.FullName);
        Console.WriteLine("Employee Age: " + emp1.Age);
        Console.WriteLine("Employee Salary: " + emp1.Salary);
        Console.WriteLine("Final Salary: " + emp1.Salary);
        Console.WriteLine("----------------------------------");

        Console.WriteLine("------Employee Profile 2 -------\n");
        Console.WriteLine("Employee ID: " + emp2.EmployeeId);
        Console.WriteLine("Employee Name: " + emp2.FullName);
        Console.WriteLine("Employee Age: " + emp2.Age);
        Console.WriteLine("Employee Salary: " + emp2.Salary);
        Console.WriteLine("Final Salary: " + emp2.Salary);
        Console.WriteLine("\n---------------------------------"); 

        emp1.GiveRaise(10);
        emp2.GiveRaise(20);

        Console.WriteLine("\n---------------------------------");

        bool result1 = emp1.DeductPenalty(500);
        bool result2 = emp2.DeductPenalty(500);

        Console.WriteLine("Penalty Success of Employee 1: " + result1);
        Console.WriteLine("Penalty Success of Employee 2: " + result2);

    }
}
