using System;
using System.Threading;
using System.Threading.Tasks;

// Problem : 3  
namespace W6D1Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Report Generation...\n");

            // Run tasks concurrently
            Task task1 = Task.Run(() => GenerateSalesReport());
            Task task2 = Task.Run(() => GenerateInventoryReport());
            Task task3 = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks to complete
            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("\nAll reports generated successfully!");
            Console.ReadLine();
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report started...");
            Thread.Sleep(3000);
            Console.WriteLine("Sales Report completed.");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report started...");
            Thread.Sleep(4000); 
            Console.WriteLine("Inventory Report completed.");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report started...");
            Thread.Sleep(2000); 
            Console.WriteLine("Customer Report completed.");
        }
    }
}


