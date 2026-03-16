using System;

namespace Week4Day5Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* var acc = new BankAccount("LT987654", "Jonas", 1200m);

            acc.Deposit(300);              // OK

            bool success = acc.Withdraw(2000);  // false (insufficient funds)
            acc.Withdraw(800);             // true

            Console.WriteLine(acc.Balance);     // 700

            acc.AccountHolder = "Jonas Jonaitis";  // OK (with validation) */

            Console.WriteLine("=============================================");


                BankAccount acc1 = new BankAccount("LT6789012", "Rajappa", 1000m);

            


            acc1.Withdraw(300);
            acc1.Deposit(500);


            Console.WriteLine("\n=============================================");


        }
    }
}
