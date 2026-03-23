using System;
using System.Threading;
using System.Threading.Tasks;

// Problem : 4 
namespace W6D1Asynchronous
{
    class Program
        {
            static async Task Main(string[] args)
            {
                Console.WriteLine("Order Processing Started...\n");

                await ProcessOrderAsync();

                Console.WriteLine("\nOrder Processing Completed Successfully!");
                Console.ReadLine();
            }

            static async Task ProcessOrderAsync()
            {
                await VerifyPaymentAsync();
                await CheckInventoryAsync();
                await ConfirmOrderAsync();
            }

            static async Task VerifyPaymentAsync()
            {
                Console.WriteLine("Verifying payment...");
                await Task.Delay(2000); // simulate delay
                Console.WriteLine("Payment verified.");
            }

            static async Task CheckInventoryAsync()
            {
                Console.WriteLine("Checking inventory...");
                await Task.Delay(3000); // simulate delay
                Console.WriteLine("Inventory available.");
            }

            static async Task ConfirmOrderAsync()
            {
                Console.WriteLine("Confirming order...");
                await Task.Delay(1500); // simulate delay
                Console.WriteLine("Order confirmed.");
            }
        }
    }



