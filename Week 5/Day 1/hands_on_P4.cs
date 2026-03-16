using System.Net.NetworkInformation;
using System;

namespace W5_D1_oops

{
        // Base Class
        class Vehicle
        {
            private string brand;
            private double rentalRatePerDay;

            // Property for Brand
            public string Brand
            {
                get { return brand; }
                set { brand = value; }
            }

            // Property for RentalRatePerDay 
            public double RentalRatePerDay
            {
                get { return rentalRatePerDay; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Rental rate cannot be negative.");
                    }
                    else
                    {
                        rentalRatePerDay = value;
                    }
                }
            }

            // Virtual Method
            public virtual double CalcRental(int days)
            {
                return rentalRatePerDay * days;
            }
        }

        // Derived Class - Car
        class Car : Vehicle
        {
            //Override Method
            public override double CalcRental(int days)
            {
                double total = RentalRatePerDay * days;
                return total + 500; // Insurance charge = 500
            }
        }

        // Derived Class - Bike
        class Bike : Vehicle
        {
            // Override Method
            public override double CalcRental(int days)
            {
                double total = RentalRatePerDay * days;
                double discount = total * 0.05; // 5% discount
                return total - discount;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter Car Rental Rate Per Day: ");
                double rate1 = double.Parse(Console.ReadLine());

                Console.Write("Enter Bike Rental Rate Per Day: ");
                double rate2 = double.Parse(Console.ReadLine());

                Console.Write("Enter Rental Days: ");
                int days = int.Parse(Console.ReadLine());

                if (days <= 0)
                {
                    Console.WriteLine("\n Invalid number of rental days.");
                    return;
                }

                // Runtime Polymorphism for Car Class
                Vehicle car = new Car();
                car.Brand = "Toyota";
                car.RentalRatePerDay = rate1;

                // Runtime Polymorphism for Bike Class
                Vehicle bike = new Bike();
                bike.Brand = "Honda";
                bike.RentalRatePerDay = rate2;

                double total1 = car.CalcRental(days);
                double total2 = bike.CalcRental(days);

            Console.WriteLine("\nTotal Rental for Car = " + total1);
            Console.WriteLine("Total Rental for Bike = " + total2);
        }
        }
    }


