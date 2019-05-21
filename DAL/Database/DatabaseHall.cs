using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL.Dtos;
using ASPNETCinema.Models;
using ASPNETCinema.DAL;

namespace ASPNETCinema.DAL
{
    public class DatabaseHall : IHallContext
    {
        private readonly DatabaseConnection _connection;

        public DatabaseHall(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public List<HallDto> GetHalls()
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                var halls = new List<HallDto>();
                SqlCommand command = new SqlCommand("SELECT Id, Price, ScreenType, Seats, SeatsTaken FROM Hall", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hall = new HallDto
                        {
                            Id = (int)reader["Id"],
                            Price = (decimal)reader["Price"],
                            ScreenType = reader["ScreenType"].ToString(),
                            Seats = (int)reader["Seats"],
                            SeatsTaken = (int)reader["SeatsTaken"]
                        };
                        halls.Add(hall);
                    }
                }
                return (halls);
            }
        }

        public void AddHall(HallModel hall)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Hall OUTPUT Inserted.ID VALUES (@Price, @ScreenType, @Seats, @SeatsTaken)", conn);
                command.Parameters.AddWithValue("@Price", hall.Price);
                command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
                command.Parameters.AddWithValue("@Seats", hall.Seats);
                command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);
                command.ExecuteNonQuery();
            }
        }

        public void EditHall(HallModel hall)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(@"UPDATE Hall SET Price = @Price, ScreenType = @ScreenType, Seats = @Seats, 
            SeatsTaken = @SeatsTaken WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", hall.Id);
                command.Parameters.AddWithValue("@Price", hall.Price);
                command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
                command.Parameters.AddWithValue("@Seats", hall.Seats);
                command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteHall(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("EXEC dbo.spHall_DeleteHall @hallId", conn);
                command.Parameters.AddWithValue("@hallId", id);
                command.ExecuteNonQuery();
            }
        }

        public HallDto GetHallById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id, Price, ScreenType, Seats, SeatsTaken FROM Hall WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hall = new HallDto
                        {
                            Id = (int)reader["Id"],
                            Price = (decimal)reader["Price"],
                            ScreenType = reader["ScreenType"]?.ToString(),
                            Seats = (int)reader["Seats"],
                            SeatsTaken = (int)reader["SeatsTaken"]
                        };
                        return hall;
                    }
                }
                return null;
            }
        }
    }
}
