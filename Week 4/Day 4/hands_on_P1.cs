using System;

class Calculator
{
    // Addition
    public int Add(int a, int b)
    {
        return a + b;
    }

    //Subtraction
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Object Creation
        Calculator calc = new Calculator();

        // Taking input
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());

        // Calling methods
        int addition = calc.Add(num1, num2);
        int subtraction = calc.Subtract(num1, num2);

        // Display output
        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}
