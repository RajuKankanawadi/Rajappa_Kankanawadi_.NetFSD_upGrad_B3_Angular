using System;
using System.Threading.Tasks;

// Problem : 2 
namespace W6D1Asynchronous

{
    internal class Program
    {

    static void Main(string[] args)
        {
            // Input
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            // Calculation
            double discountAmount = price * discount / 100;
            double finalPrice = price - discountAmount;

            // Output
            Console.WriteLine("\n--- Result ---");
            Console.WriteLine("Product: " + productName);
            Console.WriteLine("Original Price: " + price);
            Console.WriteLine("Discount: " + discount + "%");
            Console.WriteLine("Final Price: " + finalPrice);

            Console.ReadLine();
        }
    }
}

