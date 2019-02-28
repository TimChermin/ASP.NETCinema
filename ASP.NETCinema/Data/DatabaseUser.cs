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
        List<UserModel> users;

        public void AddUser(UserModel user)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Administrator) OUTPUT Inserted.ID VALUES (@Name, @Password, @Administrator)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Administrator", user.Administrator);
            command.ExecuteScalar();
            connection.Close();
        }


        public List<UserModel> GetUsers()
        {
            connection.Open();
            users = new List<UserModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
            //command.Parameters.AddWithValue("@ReleaseDate", user.ReleaseDate);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UserModel user = new UserModel(reader.GetInt32(0), reader.GetString(2), reader.GetString(3));
                    users.Add(user);
                }
            }
            connection.Close();

            return users;
        }
    }
}
