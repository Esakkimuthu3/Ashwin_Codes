using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student UgStudent = new Ug("Ashwin", 370118, 74.3);
            Student GradStudent = new Graduated("Esakki", 360011, 84.9);
            Console.WriteLine($"{UgStudent.Name}({UgStudent.StudentId}) has Passed the UnderGraduate with an Grade of {UgStudent.Grade} : {UgStudent.IsPassed(UgStudent.Grade)}");

            Console.WriteLine($"{GradStudent.Name}({GradStudent.StudentId}) has Graduated with an Grade of {GradStudent.Grade} : {GradStudent.IsPassed(GradStudent.Grade)}");
            Console.ReadLine();
        }
    }
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string name,int studid, double grade)
        {
            Name = name;
            StudentId = studid;
            Grade = grade;

        }
        public abstract bool IsPassed(double grade);
    }
    class Ug : Student
    {
        public Ug(string name, int studid, double grade) : base(name,studid,grade)
        {

        }
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class Graduated : Student
    {
        public Graduated(string name,int studid, double grade):base(name,studid,grade)
        {

        }
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }

    }
}
