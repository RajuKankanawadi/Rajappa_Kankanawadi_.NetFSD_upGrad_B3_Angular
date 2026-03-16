using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProfie_Company_HR_System
{
    class Employee
    {
        // Private fields
        private string _fullName;
        private int _age;
        private decimal _salary;
        private int _employeeId;

        // Constructor
        public Employee(int id, string name, int age, decimal salary)
        {
            _employeeId = id;

        // Using properties 
            FullName = name;
            Age = age;
            Salary = salary;
        }

        // Read-only property
        public int EmployeeId => _employeeId;

        // Salary property 
        public decimal Salary
        {
            get => _salary;
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary must be at least 1000");

                _salary = value;
            }
        }

        // FullName property
        public string FullName
        {
            get => _fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                _fullName = value.Trim();
            }
        }

        // Age property
        public int Age
        {
            get => _age;
            private set
            {
                if (value < 18 || value > 80)
                    throw new ArgumentException("Age must be between 18 and 80");

                _age = value;
            }
        }

        // Give Raise Method
        public void GiveRaise(decimal percent)
        {
            if (percent <= 0 || percent > 30)
                throw new ArgumentException("Raise must be between 1 and 30 percent");

            Salary += Salary * percent / 100;

            Console.WriteLine("New Salary: " + Salary);
        }

        // Deduct Penalty Method
        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid penalty");

            if (Salary - amount < 1000)
                return false;

            Salary -= amount;
            return true;
        }
    }
}
