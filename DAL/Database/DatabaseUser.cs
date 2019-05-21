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

        public DatabaseUser(DatabaseConnection connectionString)
        {
            _connection = connectionString;
        }

        public List<UserDto> GetUsers()
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                var users = new List<UserDto>();
                SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users", conn);

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
                return users;
            }
        }

        public void AddUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Administrator) OUTPUT Inserted.Id VALUES (@Username, @Password, @Administrator)", conn);
                command.Parameters.AddWithValue("@Username", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Administrator", user.Administrator);
                command.ExecuteNonQuery();
            }
        }

        public UserDto GetUser(string name, string password)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                var users = new List<UserModel>();
                SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users WHERE (Username = @Username AND Password = @Password)", conn);
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
                        return user;
                    }
                }
                return null;
            }
        }

        public void EditUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"UPDATE User SET IdScreening = @IdScreening, Username = @Username, Password = @Password, Administrator = @Administrator 
            WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@IdScreening", user.IdScreening);
                command.Parameters.AddWithValue("@Username", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Administrator", user.Administrator);
                command.Parameters.AddWithValue("@Id", user.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("DELETE FROM User WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public int GetUserRole(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT Administrator FROM Users WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", id);
                int role = (int)command.ExecuteScalar();


                return role;
            }
        }
        
        public UserDto DoesThisUserExist(string name)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                var users = new List<UserModel>();
                SqlCommand command = new SqlCommand("SELECT Id, Username, Password, Administrator FROM Users WHERE Username = @Username", conn);
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
                        return user;
                    }
                }
                return null;
            }
        }
    }
}
