using System;



namespace BankAccount
{
    // Custom Exception
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // BankAccount Class
    class BankAccount
    {
        private double _balance; // underscore naming

        public BankAccount(double balance)
        {
            _balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            _balance = _balance -  amount;
            Console.WriteLine("Withdrawal successful! Remaining Balance: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Balance: ");
                double bal = double.Parse(Console.ReadLine());

                BankAccount acc = new BankAccount(bal);

                Console.Write("Enter Withdraw Amount: ");
                double amt = double.Parse(Console.ReadLine());

                acc.Withdraw(amt);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
            finally
            {
                Console.WriteLine("Transaction completed.");
            }
        }
    }
}