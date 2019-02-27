using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema.Data
{
    public class DatabaseUser
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public void AddUser(UserModel user)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Administrator) OUTPUT Inserted.ID VALUES ('@Name', '@Password', '@Administrator')", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Administrator", user.Administrator);
            //command.Parameters.AddWithValue("@ReleaseDate", user.ReleaseDate);
            UserModel newUser = new UserModel(((int)command.ExecuteScalar()), user.Name, user.Password, user.Administrator);

            connection.Close();
        }
    }
}
