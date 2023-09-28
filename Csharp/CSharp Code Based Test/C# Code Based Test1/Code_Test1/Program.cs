using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Test1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("{0}*{1} = {2}", num, i, num * i);
                Console.ReadLine();
            }
        }
    }
}
