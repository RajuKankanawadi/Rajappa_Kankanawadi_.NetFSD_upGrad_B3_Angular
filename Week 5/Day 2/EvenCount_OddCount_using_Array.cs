using System;

namespace W5_D2_arrays
{
     class Program
     {
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter numbers:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int[] result = GetEvenOddTotals(arr);

            Console.WriteLine("Even Sum: " + result[0]);
            Console.WriteLine("Odd Sum: " + result[1]);
        }

        static int[] GetEvenOddTotals(int[] ar)
        {
            int evenCount = 0;
            int oddCount = 0;

            foreach (int num in ar)
            {
                if (num % 2 == 0)
                    evenCount += num;
                else
                    oddCount += num;
            }

            return new int[] { evenCount, oddCount };
        }
    }
}