using System.Net.NetworkInformation;
using System;

namespace W5_D1_oops

{
        // Base Class
        class Employee
        {
            public string Name { get; set; }
            public double BaseSalary { get; set; }

            // Virtual Method
            public virtual double CalcSalary()
            {
                return BaseSalary;
            }
        }

        // Derived Class - Manager
        class Manager : Employee
        {
            public override double CalcSalary()
            {
                return BaseSalary + (BaseSalary * 0.20);
            }
        }

        // Derived Class - Developer
        class Developer : Employee
        {
            public override double CalcSalary()
            {
                return BaseSalary + (BaseSalary * 0.10);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter Base Salary: ");
                double salary = double.Parse(Console.ReadLine());

                // Polymorphism 
                Employee manager = new Manager();
                manager.BaseSalary = salary;

                Employee developer = new Developer();
                developer.BaseSalary = salary;

                Console.WriteLine("Manager Salary = " + manager.CalcSalary());
                Console.WriteLine("Developer Salary = " + developer.CalcSalary());
            }
        }
    }

