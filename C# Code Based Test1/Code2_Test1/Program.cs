using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code2_Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Python";
            for(int j=0; j<=3;j++)
            {
                Console.WriteLine("Enter the position");
                int pos = Convert.ToInt32(Console.ReadLine());
                string newStr = " ";
                for (int i = 0; i < a.Length; i++)
                {
                    if (i != pos)
                    {
                        newStr += a[i];
                    }
                }
                Console.WriteLine(newStr);
                Console.ReadLine();
            }
            
        }
    }
}
