using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // avg();
            //maxmin();
            //MaxMinMethod2();
            marks();
        }
        // we use Average () function to find average value.
        static void avg()
        {
            int[] number = { 10, 20, 30, 40, 50 };
            double average = number.Average();
            Console.WriteLine("Averge is " + average);
            Console.ReadLine();
        }

        static void maxmin()
        {
            int[] numbers = { 10, 40, 30, 50, 23 };

            //find maximum value 
            int maxnum = numbers.Max();
            int minnum = numbers.Min();

            Console.WriteLine("The maximum and minimum numbers in the array is " + maxnum + "  " + minnum);
            Console.ReadLine();

        }

        static void MaxMinMethod2()
        {
            int[] array = { 10, 30, 40, 100, 170, 123, 3423 };
            int max = array[0];
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            Console.WriteLine("the max and min value is " + max + " " + min);
            Console.ReadLine();
        }

        static void marks()
        {
            //Console.WriteLine("enter the size of array");
            //int size = int.Parse(Console.ReadLine());


            int[] numbers = new int[10];
            //accept values in array
            Console.WriteLine("enter the marks ");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("element - {0} :", i);
                numbers[i] = Convert.ToInt32(Console.ReadLine());

            }

            //to display values in array
            //Console.WriteLine("the marks are ");

            //foreach(int number in numbers)
            //{
            //    Console.WriteLine(number);
            //    Console.ReadLine();
            //}


            //total
            int sum = 0;
            Console.WriteLine("total : ");
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine("the total is " + sum);
            Console.ReadLine();

            Console.WriteLine("the avg is ");
            double average = numbers.Average();
            Console.WriteLine("avg : ", average);

            int maxnum = numbers.Max();
            int minnum = numbers.Min();

            Console.WriteLine("The maximum and minimum numbers in the array is " + maxnum + "  " + minnum);
            Console.ReadLine();

            Console.WriteLine("array in ascending and decending ");

            Array.Sort(numbers);
            Console.WriteLine("ascending ");
            foreach (int marks in numbers)
            {
                Console.WriteLine(marks);
                Console.ReadLine();
            }


            Array.Reverse(numbers);
            Console.WriteLine("descending");
            foreach (int marks in numbers)
            {
                Console.WriteLine(marks);
                Console.ReadLine();
            }

        }
    }
}
