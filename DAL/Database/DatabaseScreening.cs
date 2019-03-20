using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DAL
{
    public class DatabaseScreening
    {
        public List<ScreeningModel> Screenings { get; set; }
        private readonly DatabaseConnection _connection;

        public DatabaseScreening(DatabaseConnection connection)
        {
            _connection = connection;
            //gave null in a spot for now
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public List<ScreeningModel> GetScreenings()
        {
            _connection.SqlConnection.Open();

            Screenings = new List<ScreeningModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM Screening", _connection.SqlConnection);
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ScreeningModel screening = new ScreeningModel(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetTimeSpan(4));
                    Screenings.Add(screening);
                }
            }
            return (Screenings);
        }


        public void AddScreening(ScreeningModel screening)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Screening OUTPUT Inserted.Id VALUES (@IdMovie, @IdHall, @DateOfScreening, @TimeOfScreening)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
            command.Parameters.AddWithValue("@IdHall", screening.HallId);
            command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
            command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);
            //MovieModel newMovie = new MovieModel(((int)command.ExecuteScalar()), screening.Id, screening.MovieId);
            command.ExecuteScalar();
        }

        public void EditScreening(ScreeningModel screening)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Screening SET IdMovie = @IdMovie, IdHall = @IdHall, DateOfScreening = @DateOfScreening, " +
                "TimeOfScreening = @TimeOfScreening WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", screening.Id);
            command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
            command.Parameters.AddWithValue("@IdHall", screening.HallId);
            command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
            command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);

            command.ExecuteNonQuery();
        }

        public void DeleteScreening(ScreeningModel screening)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Screening WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", screening.Id);
            command.ExecuteNonQuery();
        }
    }
}
