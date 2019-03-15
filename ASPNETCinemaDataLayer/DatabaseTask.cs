using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DataLayer
{
    public class DatabaseTask
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public List<TaskModel> Tasks { get; set; }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public List<TaskModel> GetTasks()
        {
            //using ASPNETCinema.Models; added
            Tasks = new List<TaskModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Task", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TaskModel task = new TaskModel(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                    Tasks.Add(task);
                }
            }

            connection.Close();
            return (Tasks);
        }
    }
}
