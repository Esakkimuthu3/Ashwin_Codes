using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace occurrenceofanletter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a word");
            string word = Console.ReadLine();

            Console.WriteLine("enter to count ");
            char occurrence = Convert.ToChar(Console.ReadLine());

            int times = count(word, occurrence);
            Console.WriteLine("the letter is repeated as "+ times + " times.");

            Console.ReadLine();
        }

        static int count(string input, char letter)
        {
            int counts = 0;
            foreach (char c in input)
            {
                if (char.ToUpper(c) == char.ToUpper(letter))
                {
                    counts++;
                }
            }
            return counts;

        }
    }
}