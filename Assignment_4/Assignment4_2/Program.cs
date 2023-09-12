using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_2
{
    class Student
    {
        private string rollno;
        private string name;
        private string class_;
        private string semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(string rollno, string name, string class_, string semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.class_ = class_;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for Subject {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            if (Array.Exists(marks, mark => mark < 35))
            {
                Console.WriteLine("Result: Failed (Marks in at least one subject is less than 35)");
                Console.ReadLine();
            }
            else if (CalculateAverage() < 50)
            {
                Console.WriteLine("Result: Failed (Average marks is less than 50)");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Result: Passed");
                Console.ReadLine();
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Roll No: {rollno}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {class_}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks in 5 subjects:");
            Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject {i + 1}: {marks[i]}");
                Console.ReadLine();
            }
        }

        private double CalculateAverage()
        {
            return marks.Sum() / 5.0;
        }

        public static void Main(string[] args)
        {
            
            Student student1 = new Student("37011", "Ashwin", "12th", "1st", "ComputerScience");
            student1.GetMarks();
            student1.DisplayResult();
            student1.DisplayData();
        }
    }
}
