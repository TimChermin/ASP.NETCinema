using Interfaces;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DAL
{
    public class DatabaseEmployee : IEmployeeContext
    {
        public List<EmployeeModel> Employees { get; set; }
        private readonly DatabaseConnection _connection;

        public DatabaseEmployee(DatabaseConnection connection)
        {
            _connection = connection;
        }

        //other things
        //List
        //Add
        //Details
        //Edit
        //Delete

        public List<EmployeeModel> GetEmployees()
        {
            _connection.SqlConnection.Open();

            Employees = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Employee", _connection.SqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel(reader.GetInt32(0), reader.GetString(1));
                    Employees.Add(employee);
                }
            }
            return (Employees);
        }

        public string GetName(int id)
        {
            return null;
        }

        IEnumerable<IEmployee> IEmployeeContext.GetEmployees()
        {
            _connection.SqlConnection.Open();

            Employees = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Employee", _connection.SqlConnection);

            var employees = new List<IEmployee>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employee = new EmployeeModel
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
}
