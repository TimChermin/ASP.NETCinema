using DAL;
using DAL.Dtos;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

        IEnumerable<IHall> IHallContext.GetHalls()
        {
            _connection.SqlConnection.Open();
            
            var halls = new List<IHall>();
            SqlCommand command = new SqlCommand("SELECT * FROM Hall", _connection.SqlConnection);

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

        public void AddHall(IHall hall)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Hall OUTPUT Inserted.ID VALUES (@Price, @ScreenType, @Seats, @SeatsTaken)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Price", hall.Price);
            command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
            command.Parameters.AddWithValue("@Seats", hall.Seats);
            command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);
            _connection.SqlConnection.Close();
        }

        public void EditHall(IHall hall)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("UPDATE Hall SET Price = @Price, ScreenType = @ScreenType, Seats = @Seats, " +
                "SeatsTaken = @SeatsTaken WHERE Id = @Id", _connection.SqlConnection);
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

        public IHall GetHallById(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Hall WHERE Id = @Id", _connection.SqlConnection);
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
            _connection.SqlConnection.Close();
            return null;
        }
    }
}
