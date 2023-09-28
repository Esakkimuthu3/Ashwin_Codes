using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy1
{
    class Student
    {
        public int stdid { get; set; }
        public string stdname { get; set; }
        public string stddob { get; set; }
        public Student(int id, string name, string dob)
        {
            stdid = id;
            stdname = name;
            stddob = dob;
        }

    }
    class Info
    {
        public void display(Student student)
        {
            Console.WriteLine("Student ID : {0}",student.stdid);
            Console.WriteLine("Student Name : {0}", student.stdname);
            Console.WriteLine("Student DOB : {0}", student.stddob);
            Console.ReadLine();
        }
    }
    class App
    {
        public static void scenario1()
        {
            Student student1 = new Student(45, "Ashwin", "20-89-7000");
            Student student2 = new Student(34, " Nived", "30-89-6000");
            Info info = new Info();
            info.display(student1);
            info.display(student2);
        }
        public static void scenario2()
        {
            Info info = new Info();
            Student[] student = new Student[2];
            student[0] = new Student(56, "Ashwin", "14-02-2000");
            student[1] = new Student(45, "Nived", "20-12-2001");
            
            foreach(Student stud in student)
            {
                info.display(stud);
            }
                
        }
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            App.scenario1();
            App.scenario2();
            Console.ReadLine();
        }
    }
}
