using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_1
{
    class Accounts
    {
        private string accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private decimal amount;
        private decimal balance;

        public Accounts(string accountNo, string customerName, string accountType)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.transactionType = '\0';
            this.amount = 0;
            this.balance = 0;
        }

        public void Credit(decimal amount)
        {
            if (amount > 0)
            {
                this.transactionType = 'D';
                this.amount = amount;
                this.balance += amount;
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Amount should be greater than zero.");
                Console.ReadLine();
            }
        }

        public void Debit(decimal amount)
        {
            if (amount > 0 && this.balance >= amount)
            {
                this.transactionType = 'W';
                this.amount = amount;
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                Console.ReadLine();
            }
        }

        public void ShowData()
        {
            Console.WriteLine("Account Number: " + this.accountNo);
            Console.WriteLine("Customer Name: " + this.customerName);
            Console.WriteLine("Account Type: " + this.accountType);
            Console.WriteLine("Transaction Type: " + this.transactionType);
            Console.WriteLine("Amount: " + this.amount);
            Console.WriteLine("Balance: " + this.balance);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Accounts account1 = new Accounts("37011", "Ashwin", "Savings");
            account1.Credit(1000);
            account1.ShowData();

            account1.Debit(500);
            account1.ShowData();
        }
    }
}
