using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account("37011", "Ashwin", "Savings");
            Console.WriteLine("Enter the Transaction type: D or W  ");
            string a = Console.ReadLine();
            if(a=="D")
            {
                account1.Deposit(1000);
                account1.Display();
            }
            
            else if(a=="W")
            {
                account1.Withdraw(500);
                account1.Display();
            }

            else
            {
                Console.WriteLine("You have selected the type of transaction which is not listed above.");
                Console.ReadLine();
            }
            
        }
    }

    class Account
    {
        private string accountNo;
        private string customerName;
        private string accountType;
        private decimal balance;

        public Account(string accountNo, string customerName, string accountType)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.balance += amount;
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Amount should be greater than zero.");
                Console.ReadLine();
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && this.balance >= amount)
            {
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                Console.ReadLine();
            }
        }

        public void Display()
        {
            Console.WriteLine("Account Number: " + this.accountNo);
            Console.WriteLine("Customer Name: " + this.customerName);
            Console.WriteLine("Account Type: " + this.accountType);
            Console.WriteLine("Balance: " + this.balance);
            Console.ReadLine();
        }
    }
}
