using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using System.Data.SqlClient;
using DAL;
using DAL.Dtos;

namespace ASPNETCinema.DAL
{
    public class DatabaseUser : IUserContext
    {
        private readonly DatabaseConnection _connection;

        public DatabaseUser(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public List<UserDto> GetUsers()
        {
            _connection.SqlConnection.Open();
            var users = new List<UserDto>();
            SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users", _connection.SqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new UserDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Username"]?.ToString(),
                        Password = reader["Password"]?.ToString(),
                        Administrator = (int)reader["Administrator"]
                    };
                    users.Add(user);
                }
            }
            _connection.SqlConnection.Close();
            return users;
        }

        public void AddUser(UserModel user)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Administrator) OUTPUT Inserted.Id VALUES (@Username, @Password, @Administrator)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Administrator", user.Administrator);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public UserDto GetUser(string name, string password)
        {
            _connection.SqlConnection.Open();
            var users = new List<UserModel>();
            SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users WHERE (Username = @Username AND Password = @Password)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", name);
            command.Parameters.AddWithValue("@Password", password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new UserDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Username"]?.ToString(),
                        Password = reader["Password"]?.ToString(),
                        Administrator = (int)reader["Administrator"]
                    };
                    _connection.SqlConnection.Close();
                    return user;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }

        public void EditUser(UserModel user)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand(@"UPDATE User SET IdScreening = @IdScreening, Username = @Username, Password = @Password, Administrator = @Administrator 
            WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdScreening", user.IdScreening);
            command.Parameters.AddWithValue("@Username", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Administrator", user.Administrator);
            command.Parameters.AddWithValue("@Id", user.Id);

            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void DeleteUser(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM User WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public int GetUserRole(int id)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Administrator FROM Users WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            int role = (int)command.ExecuteScalar();

            _connection.SqlConnection.Close();
            return role;
        }
        
        public UserDto DoesThisUserExist(string name)
        {
            _connection.SqlConnection.Open();
            var users = new List<UserModel>();
            SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users WHERE Username = @Username", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", name);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new UserDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Username"]?.ToString(),
                        Password = reader["Password"]?.ToString(),
                        Administrator = (int)reader["Administrator"]
                    };
                    _connection.SqlConnection.Close();
                    return user;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }

       
    }
}
