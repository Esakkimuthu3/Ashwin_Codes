using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number of matches played:");
            if(int.TryParse(Console.ReadLine(), out int match_count)&& match_count >0)
            {
                Cricket game = new Cricket();
                game.Points(match_count);    
            }
            else
            {
                Console.WriteLine("Wrong Input, Check the value which is given as an Input and Enter the valid Input.");
            }
            Console.ReadLine();
        }
    }
    class Cricket
    {
        public void Points(int match_count)
        {
            int[] Scores = new int[match_count];
            int Sum = 0;
            for(int i = 0 ; i<match_count ;i++)
            {
                Console.WriteLine($"Enter the score{i+1}:");
                if(int.TryParse(Console.ReadLine(),out int Score))
                {
                    Scores[i] = Score;
                    Sum += Score;
                }
                else
                {
                    Console.WriteLine("Wrong score, Enter the valid score details");
                    i--;
                }
            }
            double Avg = Convert.ToDouble(Sum / match_count);
            Console.WriteLine("Total Score: {0}", Sum);
            Console.WriteLine("Average Scored: {0}", Avg);
            Console.ReadLine();
            
        }
    }
    
}
