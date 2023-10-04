using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_2
{
    delegate int Calculator(int a, int b);

    class Program
    {
        static int Addition(int a, int b)
        {
            return a + b;
        }

        static int Subtraction(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Division(int a , int b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            Calculator cal = null;

            Console.WriteLine("Enter any integer values for n1 and n2:");
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the choice:-\n1. addition:\n2. subtraction:\n3. multiplication:\n4. Diviosn:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    cal = new Calculator(Addition);
                    Console.WriteLine("The sum is: " + cal(n1, n2));
                    break;
                case 2:
                    cal = new Calculator(Subtraction);
                    Console.WriteLine("The difference is: " + cal(n1, n2));
                    break;
                case 3:
                    cal = new Calculator(Multiply);
                    Console.WriteLine("The product is: " + cal(n1, n2));
                    break;
                case 4:
                    cal = new Calculator(Division);
                    Console.WriteLine("The division is :" + cal(n1, n2));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Input choice has to be between 1 to 4.");
                    break;
            }

            Console.ReadLine();
        }
    }
}
