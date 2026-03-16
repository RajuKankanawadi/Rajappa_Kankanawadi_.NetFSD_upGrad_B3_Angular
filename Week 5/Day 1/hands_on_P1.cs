using System.Net.NetworkInformation;
using System;

namespace W5_D1_oops

{ 
        class BankAccount
        {
            // Private Fields 

            private string accountNumber;
            private decimal balance;

            // Property for Account Number
            public string AccountNumber
            {
                get { return accountNumber; }
                set { accountNumber = value; }
            }

            // Property for Balance 
            public decimal Balance
            {
                get { return balance; }
            }

            // Deposit Method
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid deposit amount.");
                    return;
                }

                balance = balance + amount;
                Console.WriteLine("Deposit Successful.");
                Console.WriteLine("Current Balance = " + balance);
            }

            // Withdraw Method
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal amount.");
                    return;
                }

                if (amount > balance)
                {
                    Console.WriteLine("Insufficient Balance.");
                    return;
                }

                balance = balance - amount;
                Console.WriteLine("Withdrawal Successful.");
                Console.WriteLine("Current Balance = " + balance);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                BankAccount acc = new BankAccount();

                Console.Write("Enter Account Number: ");
                acc.AccountNumber = Console.ReadLine();

                Console.Write("Enter Deposit Amount: ");
                decimal deposit = decimal.Parse(Console.ReadLine());

                acc.Deposit(deposit);

                Console.Write("Enter Withdraw Amount: ");
                decimal withdraw = decimal.Parse(Console.ReadLine());

                acc.Withdraw(withdraw);

                Console.WriteLine("Final Balance = " + acc.Balance);
            }
        }
    }

