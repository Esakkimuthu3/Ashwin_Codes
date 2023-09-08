using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            //lenght();
            //2.
            //Console.WriteLine("enter a string ");

            //string userip = Console.ReadLine();

            //string reverse = revstr(userip);
            //Console.WriteLine($"reverse is {reverse}");
            //Console.ReadLine();
            //3.

            // twoString();
        }

        static void lenght()
        {
            Console.WriteLine("enter the string ");

            string userip = Console.ReadLine();

            double iplength = userip.Length;
            Console.WriteLine($"the lenght is {iplength}");
            Console.ReadLine();
        }

        static string revstr(string input)
        {
            StringBuilder reversed = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            return reversed.ToString();
        }

        static void twoString()
        {
            Console.WriteLine("enter the word1");
            string word1 = Console.ReadLine();
            Console.WriteLine("enter the word2");
            string word2 = Console.ReadLine();


            // we are using string.equal function 

            bool equal = string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase);

            if (equal)
            {
                Console.WriteLine("words are equal");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("words are not equal");
                Console.ReadLine();
            }
        }
    }
}
