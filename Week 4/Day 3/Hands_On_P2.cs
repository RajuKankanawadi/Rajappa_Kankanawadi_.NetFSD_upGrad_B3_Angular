/* Problem : 2 -- Create a simple calculator application that 
  performs basic arithmetic operations. */

using System;

class Problem2
{
    static void Main(string[] args) {
        //  first number
        Console.WriteLine("Enter First Number: ");
        int num1 = int.Parse(Console.ReadLine());

        //  second number
        Console.WriteLine("Enter Second Number: ");
        int num2 = int.Parse(Console.ReadLine());

        // Accept operator
        Console.WriteLine("Enter Operator (+, -, *, /): ");
        char op = char.Parse(Console.ReadLine());

        int result = 0;

        // Switch statement 
        switch (op)
        {
            case '+':
                result = num1 + num2;
                Console.WriteLine("Result: " + result);
                break;

            case '-':
                result = num1 - num2;
                Console.WriteLine("Result: " + result);
                break;

            case '*':
                result = num1 * num2;
                Console.WriteLine("Result: " + result);
                break;

            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine("Result: " + result);
                }
                break;

            default:
                Console.WriteLine("Invalid Operator!");
                break;
        }
    }
}