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



                    using (SqlCommand command = new SqlCommand("AddEmployees", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@empno", 7775);
                        command.Parameters.AddWithValue("@empname", "Ashwi");
                        command.Parameters.AddWithValue("@empsal", 8000.00);
                        command.Parameters.AddWithValue("@emptype", "F");



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
