using System;
using System.Diagnostics;
using System.IO;

// Problem : 5
namespace W6D1Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Trace 
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("order_log.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            try
            {
                ProcessOrder();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("Order processing failed. Check log file.");
            }

            Console.WriteLine("\nProcess completed. Check order_log.txt for trace logs.");
            Console.ReadLine();
        }

        static void ProcessOrder()
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();
        }

        static void ValidateOrder()
        {
            Trace.TraceInformation("Step 1: Validating Order...");
            Console.WriteLine("Validating Order...");
        }

        static void ProcessPayment()
        {
            Trace.TraceInformation("Step 2: Processing Payment...");
            Console.WriteLine("Processing Payment...");

            // Simulate failure for debugging purpose
            bool paymentSuccess = true;

            if (!paymentSuccess)
            {
                Trace.WriteLine("Payment failed!");
                throw new Exception("Payment processing error.");
            }
        }

        static void UpdateInventory()
        {
            Trace.TraceInformation("Step 3: Updating Inventory...");
            Console.WriteLine("Updating Inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.TraceInformation("Step 4: Generating Invoice...");
            Console.WriteLine("Generating Invoice...");
        }
    }
}