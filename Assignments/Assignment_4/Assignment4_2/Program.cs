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
        private string classStd;
        private string semester;

        private int[] marks = new int[5];

        public Student(string rollno, string name, string classStd, string semester)
        {
            this.rollno = rollno;
            this.name = name;
            this.classStd = classStd;
            this.semester = semester;

        }

        public void GetMarks()
        {
            Console.WriteLine("Enter marks of an 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter Subject marks {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            if (Array.Exists(marks, mark => mark < 35))
            {
                Console.WriteLine("Failed");
                Console.ReadLine();
            }
            else if (CalculateAverage() < 50)
            {
                Console.WriteLine("Failed");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Passed");
                Console.ReadLine();
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Roll No: {rollno}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {classStd}");
            Console.WriteLine($"Semester: {semester}");

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
            Console.WriteLine("Enter the student details:");
            Console.WriteLine("Enter RollNo:");
            string rollno = Console.ReadLine();
            Console.WriteLine("Enter Name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Grade:");
            string Grade = Console.ReadLine();
            Console.WriteLine("Enter Semester:");
            string Semester = Console.ReadLine();
            Student student1 = new Student(rollno, Name, Grade, Semester);
            student1.GetMarks();
            student1.DisplayResult();
            student1.DisplayData();
        }
    }
}