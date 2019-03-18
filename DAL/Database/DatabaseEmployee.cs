using ASPNETCinema.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DAL
{
    public class DatabaseEmployee : IEmployeeContext
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public List<EmployeeModel> Employees { get; set; }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public List<EmployeeModel> GetEmployees()
        {
            //using ASPNETCinema.Models; added
            Employees = new List<EmployeeModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel(reader.GetInt32(0), reader.GetString(1));
                    Employees.Add(employee);
                }
            }

            connection.Close();
            return (Employees);
        }

        public string GetName(int id)
        {
            return null;
        }

        IEnumerable<IEmployee> IEmployeeContext.GetEmployees()
        {
            //using ASPNETCinema.Models; added
            Employees = new List<EmployeeModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);

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

            connection.Close();
            return (employees);
        }
    }
}
