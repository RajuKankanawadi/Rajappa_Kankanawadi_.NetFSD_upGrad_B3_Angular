using System;

namespace ConsoleApp35
{
    class Product
    {
        private int _productId;
        private string _productName;
        private float _unitPrice;
        private int _qty;

        public Product(int id)
        {
            _productId = id;
        }

        public int ProductId
        {
            get { return _productId; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public float UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }


        //show product details
        public void ShowDetails()
        {
            float totalAmount = _unitPrice * _qty;

            Console.WriteLine("Product ID   : " + _productId);
            Console.WriteLine("Product Name : " + _productName);
            Console.WriteLine("Unit Price   : " + _unitPrice);
            Console.WriteLine("Quantity     : " + _qty);
            Console.WriteLine("Total Amount : " + totalAmount);
        }
    }
    
   
            
    























































    internal class Program
    {


        static int CountVowels(String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            int count = 0;
            string voewls = "aeiouAEIOU";

            foreach (char ch in text)
            {
                if (voewls.Contains(ch))
                {
                    count++;
                }
            }
            return count;

        }

        static void Greeting()
        {
            Console.WriteLine("Welcome to C# Methods");
        }

        static void Greeting(string uname)
        {
            Console.WriteLine($"Hi {uname}, Good morning...!");
        }

        static int GetSum(int x, int y)
        {
            int z = x + y;
            return z;
        }


        static string GetCurrentTime()
        {
            string str = DateTime.Now.ToString("T");
            return str;
        }

        static void Main(string[] args)
        {

            Greeting();
            Greeting();
            Console.WriteLine("---------------------------");

            Greeting("Narasimha");
            Greeting("Scott");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Sum Result : " + GetSum(10, 20));
            Console.WriteLine("Sum Result : " + GetSum(402, 503));

            Console.WriteLine("---------------------------");

            Console.WriteLine("Current Time : " + GetCurrentTime());

            Console.WriteLine("---------------------------");



            // Creating object using constructor
            Product p = new Product(101);

            // Setting values using properties
            p.ProductName = "Laptop";
            p.UnitPrice = 50000;
            p.Quantity = 2;

            // Display details
            p.ShowDetails();

            Console.ReadLine();
        

            string input = "Programming";
            int result = Program.CountVowels(input);
            Console.WriteLine($"input: {input} result: {result}");


            Console.ReadLine();
        }
    }
}
