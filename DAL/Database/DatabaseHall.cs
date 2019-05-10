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

        //other things
        //List
        //Add
        //Details
        //Edit
        //Delete

        public List<HallDto> GetHalls()
        {
            _connection.SqlConnection.Open();
            
            var halls = new List<HallDto>();
            SqlCommand command = new SqlCommand("SELECT Id, Price, ScreenType, Seats, SeatsTaken FROM Hall", _connection.SqlConnection);

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
            _connection.SqlConnection.Close();
            return (halls);
        }

        public void AddHall(HallModel hall)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Hall OUTPUT Inserted.ID VALUES (@Price, @ScreenType, @Seats, @SeatsTaken)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Price", hall.Price);
            command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
            command.Parameters.AddWithValue("@Seats", hall.Seats);
            command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void EditHall(HallModel hall)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand(@"UPDATE Hall SET Price = @Price, ScreenType = @ScreenType, Seats = @Seats, 
            SeatsTaken = @SeatsTaken WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", hall.Id);
            command.Parameters.AddWithValue("@Price", hall.Price);
            command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
            command.Parameters.AddWithValue("@Seats", hall.Seats);
            command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);

            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void DeleteHall(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Hall WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public HallDto GetHallById(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT Id, Price, ScreenType, Seats, SeatsTaken FROM Hall WHERE Id = @Id", _connection.SqlConnection);
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
                    _connection.SqlConnection.Close();
                    return hall;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }
    }
}
