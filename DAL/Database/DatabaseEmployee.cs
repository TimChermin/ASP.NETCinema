
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
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT Id, Name FROM Employee WHERE Id = @Id", _connection.SqlConnection);
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
                    _connection.SqlConnection.Close();
                    return employee;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }

        public List<EmployeeDto> GetEmployees()
        {
            _connection.SqlConnection.Open();
            
            SqlCommand command = new SqlCommand("SELECT Id, Name FROM Employee", _connection.SqlConnection);

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

        public void AddEmployee(EmployeeModel employee)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Employee OUTPUT Inserted.Id VALUES (@Name)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void EditEmployee(EmployeeModel employee)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("UPDATE Employee SET Name = @Name WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);

            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void DeleteEmployee(int id)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("EXEC dbo.spEmployee_DeleteEmployee @employeeId", _connection.SqlConnection);
            command.Parameters.AddWithValue("@employeeId", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        
    }
}
