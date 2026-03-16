using System.Net.NetworkInformation;
using System;

namespace W5_D1_oops

{
        // Base Class
        class Product
        {
            private string name;
            private double price;

            // Property for Name
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            // Property for Price 
            public double Price
            {
                get { return price; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Price cannot be negative.");
                    }
                    else
                    {
                        price = value;
                    }
                }
            }

            // Virtual Method
            public virtual double CalcDiscount()
            {
                return price;
            }
        }

        // Derived Class - Electronics
        class Electronics : Product
        {
            // Override Method
            public override double CalcDiscount()
            {
                return Price - (Price * 0.05);   // 5% discount
            }
        }

        // Derived Class - Clothing
        class Clothing : Product
        {
            // Override Method
            public override double CalcDiscount()
            {
                return Price - (Price * 0.15);   // 15% discount
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter Electronics Price: ");
                double elec_Price = double.Parse(Console.ReadLine());

                Console.Write("Enter Clothes Price: ");
                double cloth_Price = double.Parse(Console.ReadLine());

            Product electronics = new Electronics();
                electronics.Name = "Laptop";
                electronics.Price = elec_Price;

            Product clothing = new Electronics();
                clothing.Name = "Shirt";
                clothing.Price = cloth_Price;
            
                double finalPrice1 = electronics.CalcDiscount();
                double finalPrice2 = clothing.CalcDiscount();


                Console.WriteLine("\nFinal Price after 5% discount of Electronics product : " + finalPrice1);
                Console.WriteLine("Final Price after 15% discount of Clothing product : " + finalPrice2);

        }
        }
    }


