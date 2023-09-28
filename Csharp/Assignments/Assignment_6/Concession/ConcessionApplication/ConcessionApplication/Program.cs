using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concession;

namespace ConsessionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name ");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter your age");
            int Age = Convert.ToInt32(Console.ReadLine());

            Concession.concession calculator = new Concession.concession
            {
                Name = Name,
                Age = Age
            };
            calculator.CalculatorConsession();
            Console.ReadLine();


        }
    }
}
