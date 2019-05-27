
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL.Dtos;
using ASPNETCinema.Models;

namespace ASPNETCinema.DAL
{
    public class DatabaseEmployee : IEmployeeContext
    {
        private readonly DatabaseConnection _connection;

        public DatabaseEmployee(DatabaseConnection connection)
        {
            _connection = connection;
        }
        

        public EmployeeDto GetEmployeeById(int id)
        {
            using (var conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id, Name FROM Employee WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new EmployeeDto
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"]?.ToString(),
                        };
                        return employee;
                    }
                }
                return null;
            }
        }

        public List<EmployeeDto> GetEmployees()
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id, Name FROM Employee", conn);
                var employees = new List<EmployeeDto>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new EmployeeDto
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"]?.ToString()
                        };

                        employees.Add(employee);
                    }
                }
                return (employees);
            }
        }

        public void AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Employee OUTPUT Inserted.Id VALUES (@Name)", conn);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.ExecuteNonQuery();
            }
        }

        public void EditEmployee(EmployeeModel employee)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Employee SET Name = @Name WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE Employee.Id = @EmployeeId", conn);
                command.Parameters.AddWithValue("@EmployeeId", id);
                command.ExecuteNonQuery();
            }
        }

        
    }
}
