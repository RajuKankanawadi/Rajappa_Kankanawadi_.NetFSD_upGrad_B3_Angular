using System;

namespace DivideCalc

        // Problem 2: Safe Division Calculator
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Division Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            while (true) 
            {
                try
                {
                    Console.Write("\nEnter Numerator: ");
                    int num = int.Parse(Console.ReadLine());

                    Console.Write("Enter Denominator: ");
                    int den = int.Parse(Console.ReadLine());

                    calc.Divide(num, den);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input! Please enter numbers only.");
                }
            }
        }
    }
}