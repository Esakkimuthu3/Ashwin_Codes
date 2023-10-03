using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study1
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public Student(int id, string name, DateTime dob)
        {
            Id = id;
            Name = name;
            DOB = dob;
        }
    }

    class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student DOB: {student.DOB.ToShortDateString()}");
        }
    }

    public class App
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose any one:");
                Console.WriteLine("1. Scenario 1");
                Console.WriteLine("2. Scenario 2");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Scenario1();
                            break;
                        case 2:
                            Scenario2();
                            break;
                        case 3:
                            Console.WriteLine("Logging Out");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            Console.ReadLine();
        }

        public static void Scenario1()
        {
            Console.WriteLine("Scenario 1:");

            Console.Write("Enter the total number of students to be accepted and give the deatails: ");
            int total = int.Parse(Console.ReadLine());

            Student[] students = new Student[total];
            Info info = new Info();

            for (int i = 0; i < total; i++)
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student DOB in the format (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("Student Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }

        public static void Scenario2()
        {
            Console.WriteLine("\nScenario 2:");
            Console.Write("Enter the total number of students for giving details: ");
            int total = int.Parse(Console.ReadLine());

            Student[] students = new Student[total];
            Info info = new Info();

            for (int i = 0; i < total; i++)
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student DOB (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("Student Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }
    }
}
