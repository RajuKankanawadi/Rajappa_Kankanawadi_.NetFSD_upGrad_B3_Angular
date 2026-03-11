

/* Problem : 4 -- Scenario Create a .NET 8 console application that analyzes numbers between 1 and N. 
  Requirements: --> Accept a number N from user. --> Use loops to: Count even numbers.Count odd numbers 
  --> Calculate sum of all numbers. -->  Display results
*/


using System;

class Problem4
{
    static void Main(string[] args)
    {
        // enter number from user
        Console.Write("Enter Number: ");
        int n = int.Parse(Console.ReadLine());

        int evenCount = 0;
        int oddCount = 0;
        int sum = 0;

        // for loop
        for (int i = 1; i <= n; i++)
        {
            // sum
            sum = sum + i;

            // Check even or odd
            if (i % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        Console.WriteLine("Even Count: " + evenCount);
        Console.WriteLine("Odd Count: " + oddCount);
        Console.WriteLine("Sum: " + sum);
    }
}
