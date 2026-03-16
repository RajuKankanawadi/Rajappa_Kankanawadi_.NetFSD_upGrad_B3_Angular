using System;
using System.Collections.Generic;
using System.Text;

namespace Week4Day5Project
{
    internal class BankAccount
    {

        private decimal _balance;
        private string _accountNumber;
        private string _accountHolder;

        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        }

        public string AccountHolder
        {
            get { return _accountHolder; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Account Holder Name cannot be empty");
                }

                _accountHolder = value;
            }
        }


        public BankAccount(string accountNumber, string accountHolder, decimal balance = 0)
        {

            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new ArgumentNullException("Account Number cannot be empty");
            }

            if (string.IsNullOrEmpty(accountHolder))
            {
                throw new ArgumentNullException("Account Holder Name cannot be empty");
            }

            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException("Balance cannot be nagative");
            }


            _accountNumber = accountNumber;
            _accountHolder = accountHolder;
            _balance = balance;
        }



        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than zero");
            }

            _balance += amount;

            string last4 = _accountNumber.Substring(_accountNumber.Length - 4);

            Console.WriteLine("\n----- BANK SMS ALERT -----");
            Console.WriteLine($"{DateTime.Now:dd-MMM-yyyy hh:mm tt}");
            Console.WriteLine($"INR {amount:F2} credited to A/C XXXX{last4}");
            Console.WriteLine($"Available Balance: INR {_balance:F2}");
            Console.WriteLine("--------------------------");
        }


        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount cannot be zero or less than zero");
                return false;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient Balance");
                return false;
            }

            _balance -= amount;

            string last4 = _accountNumber.Substring(_accountNumber.Length - 4);

            Console.WriteLine("\n----- BANK SMS ALERT -----");
            Console.WriteLine($"{DateTime.Now:dd-MMM-yyyy hh:mm tt}");
            Console.WriteLine($"INR {amount:F2} debited from A/C XXXX{last4}");
            Console.WriteLine($"Available Balance: INR {_balance:F2}");
            Console.WriteLine("--------------------------");

            return true;
        }
    }
}


