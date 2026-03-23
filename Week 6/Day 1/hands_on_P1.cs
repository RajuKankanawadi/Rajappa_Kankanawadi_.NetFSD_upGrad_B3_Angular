using System;
using System.Threading.Tasks;

// Problem : 1 Asynchronous File Logger
namespace W6D1Asynchronous

{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            // Call async logging 
            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Error occurred");
            Task log4 = WriteLogAsync("User logged out");

            Console.WriteLine("\nLogging in progress...\n");

            // Wait for all logs 
            await Task.WhenAll(log1, log2, log3, log4);

            Console.WriteLine("\nAll logs written successfully!");
        }

        // Async method 
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");

            //delay 
            await Task.Delay(2000);

            Console.WriteLine($"Finished writing log: {message}");
        }
    }
}