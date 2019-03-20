using ASPNETCinema.Models;
using DAL;
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
        private List<HallModel> halls;
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
            
            halls = new List<HallModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Hall", _connection.SqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    HallModel hall = new HallModel(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                    halls.Add(hall);
                }
            }

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
            HallModel newHall = new HallModel(((int)command.ExecuteScalar()), hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
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
        }

        public void DeleteHall(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Hall WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        public IHall GetHallById(int id)
        {
            _connection.SqlConnection.Open();

            halls = new List<HallModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Hall WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    IHall hall = new HallModel
                    {
                        Id = (int)reader["Id"],
                        Price = (decimal)reader["Name"],
                        ScreenType = reader["Description"]?.ToString(),
                        Seats = (int)reader["ReleaseDate"],
                        SeatsTaken = (int)reader["LastScreeningDate"]
                    };

                    return hall;
                }
            }
            return null;
        }
    }
}
