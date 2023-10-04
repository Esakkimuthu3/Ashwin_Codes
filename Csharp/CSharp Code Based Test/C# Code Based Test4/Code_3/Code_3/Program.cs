using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_3
{
    class Employee
    {
        public int EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Title { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>()
            {
                 new Employee() { EmpId = 1001, Fname = "Malcolm", Lname = "Daruwalla", Title = "Manager", Dob = new DateTime(1984, 11, 16), Doj = new DateTime(2011, 6, 8), City = "Mumbai" },
                 new Employee() { EmpId = 1002, Fname = "Asdin", Lname = "Dhalla", Title = "AssistantManager", Dob = new DateTime(1984, 8, 20), Doj = new DateTime(2012, 7, 7), City = "Mumbai" },
                 new Employee() { EmpId = 1003, Fname = "Madhavi", Lname = "Oza", Title = "Consultant", Dob = new DateTime(1987, 11, 14), Doj = new DateTime(2015, 4, 12), City = "Pune" },
                 new Employee() { EmpId = 1004, Fname = "Saba", Lname = "Sheik", Title = "SE", Dob = new DateTime(1990, 6, 3), Doj = new DateTime(2016, 2, 2), City = "Pune" },
                 new Employee() { EmpId = 1005, Fname = "Nazia", Lname = "Sheik", Title = "SE", Dob = new DateTime(1991, 3, 8), Doj = new DateTime(2016, 2, 2), City = "Mumbai" },
                 new Employee() { EmpId = 1006, Fname = "Amit", Lname = "Pathak", Title = "Consultant", Dob = new DateTime(1989, 11, 7), Doj = new DateTime(2014, 8, 8), City = "Chennai" },
                 new Employee() { EmpId = 1007, Fname = "Vijay", Lname = "Natrajan", Title = "Consultant", Dob = new DateTime(1989, 12, 2), Doj = new DateTime(2015, 6, 1), City = "Mumbai" },
                 new Employee() { EmpId = 1008, Fname = "Rahul", Lname = "Dubey", Title = "Associate", Dob = new DateTime(1993, 11, 11), Doj = new DateTime(2014, 6, 11), City = "Chennai" },
                 new Employee() { EmpId = 1009, Fname = "Suresh", Lname = "Mistry", Title = "Associate", Dob = new DateTime(1992, 8, 12), Doj = new DateTime(2014, 3, 12), City = "Chennai" },
                 new Employee() { EmpId = 1010, Fname = "Sumit", Lname = "Shah", Title = "Manager", Dob = new DateTime(1991, 4, 12), Doj = new DateTime(2016, 2, 1), City = "Pune" }
            };

            //First Query

            Console.WriteLine("First Query:\n");

            var AllEmployees = from emp in empList select emp;
            Console.WriteLine("Details of all Employees:");
            foreach (var emp in AllEmployees)
            {
                Console.WriteLine($"{emp.EmpId} \t {emp.Fname} \t {emp.Lname} \t {emp.Title} \t {emp.Dob.ToShortDateString()} \t {emp.Doj.ToShortDateString()} \t {emp.City}");
            }
            Console.WriteLine("\n");
            Console.ReadLine();

            //Second Query

            Console.WriteLine("Second Query:\n");

            var EmployeesNotInMumbai = from emp in empList where emp.City != "Mumbai" select emp;
            Console.WriteLine("\nEmployees Who is not in Mumbai are:");
            foreach (var emp in EmployeesNotInMumbai)
            {
                Console.WriteLine($"{emp.EmpId} \t {emp.Fname} \t {emp.Lname} \t {emp.Title} \t {emp.Dob.ToShortDateString()} \t {emp.Doj.ToShortDateString()} \t {emp.City}");
            }
            Console.WriteLine("\n");
            Console.ReadLine();

            //Third Query

            Console.WriteLine("Third Query:\n");

            var AsstManagers = from emp in empList where emp.Title == "AssistantManager" select emp;
            Console.WriteLine("\nAssistant Managers:");
            foreach (var emp in AsstManagers)
            {
                Console.WriteLine($"{emp.EmpId} \t {emp.Fname} \t {emp.Lname} \t {emp.Title} \t {emp.Dob.ToShortDateString()} \t {emp.Doj.ToShortDateString()} \t {emp.City}");
            }
            Console.WriteLine("\n");
            Console.ReadLine();

            //Fourth Query

            Console.WriteLine("Fourth Query:\n");

            var employeesWithLastNameStartingWithS = from emp in empList where emp.Lname.StartsWith("S") select emp;
            Console.WriteLine("\nEmployees with LastName whose Last name starts with S :");
            foreach (var emp in employeesWithLastNameStartingWithS)
            {
                Console.WriteLine($"{emp.EmpId} {emp.Fname} {emp.Lname} {emp.Title} {emp.Dob.ToShortDateString()} {emp.Doj.ToShortDateString()} {emp.City}");
            }
            Console.ReadLine();
        }
    }
}
