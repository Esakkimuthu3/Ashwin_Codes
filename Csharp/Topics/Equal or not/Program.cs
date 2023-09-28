using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualorNot
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Console.WriteLine("Enter the first integer");
            //int a=Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the Second integer");
            //int b = Convert.ToInt32(Console.ReadLine()); 
            //if(a==b)
            //{
            //    Console.WriteLine("It is equal ");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("It is not equal");
            //    Console.ReadLine();
            //}





            //Console.WriteLine("Enter the integer");
            //int n = Convert.ToInt32(Console.ReadLine());
            //if (n>=0)
            //{
            //    Console.WriteLine("Positive ");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("Negative");
            //    Console.ReadLine();
            //}



            //Console.WriteLine("Enter the first integer:");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the Operand: ");
            //String b = Console.ReadLine();
            //Console.WriteLine("Enter the Second Integer: ");
            //int c = Convert.ToInt32(Console.ReadLine());
            //if(b=="+")
            //{
            //    Console.WriteLine(a+c);
            //    Console.ReadLine();
            //}
            //else if(b=="-")
            //{
            //    Console.WriteLine(a-c);
            //    Console.ReadLine();
            //}
            //else if(b=="*")
            //{
            //    Console.WriteLine(a*c);
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine(a/c);
            //    Console.ReadLine();
            //}




            Console.WriteLine("Enter the first integer:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Operand: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Integer: ");
            int c = Convert.ToInt32(Console.ReadLine());
            switch(b)
            {
                case + :
                    Console.WriteLine(a+b);
                    break;

                case - :
                    Console.WriteLine(a - b);
                    break;
            }
        }
    }
}
