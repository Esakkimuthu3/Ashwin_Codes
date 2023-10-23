using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CodeBasedTest6
{
    
            class Program
        {
            static void Main(string[] args)
            {
                string connectionString = @"Server=ICS-LT-CRNK9K3\SQLEXPRESS;Database=codebasedtest6;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    using (SqlCommand command = new SqlCommand("AddEmployeese", connection))
                    {
                    Console.WriteLine("Enter the emp name");
                    string empname = Console.ReadLine();
                    Console.WriteLine("Enter the emp salary");
                    string empsal = Console.ReadLine();
                    Console.WriteLine("Enter the emp type (either F or P)");
                    string emptype = Console.ReadLine();



                    command.CommandType = CommandType.StoredProcedure;

                    
                        command.Parameters.AddWithValue("@empname", empname);
                        command.Parameters.AddWithValue("@empsal", empsal);
                        command.Parameters.AddWithValue("@emptype", emptype);



                        command.ExecuteNonQuery();
                    }
                }



                Console.WriteLine("Employee Inserted successfully.");



                // Display all records
                DisplayAllEmployeeRecords(connectionString);
            Console.ReadLine();
            }



            // Define the DisplayAllEmployeeRecords method outside of Main
            static void DisplayAllEmployeeRecords(string connectionString)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    using (SqlCommand command = new SqlCommand("SELECT * FROM Code_Employees", connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Employee ID: {reader["empno"]}, Name: {reader["empname"]}, Salary: {reader["empsal"]}, Type: {reader["emptype"]}");
                        }
                    }
                }
            }

    }
}
