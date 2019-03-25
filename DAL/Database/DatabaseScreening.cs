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
    public class DatabaseScreening : IScreeningContext
    {
        private readonly DatabaseConnection _connection;

        public DatabaseScreening(DatabaseConnection connection)
        {
            _connection = connection;
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IEnumerable<IScreening> GetScreenings()
        {
            _connection.SqlConnection.Open();

            var screenings = new List<IScreening>();
            SqlCommand command = new SqlCommand("SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening", _connection.SqlConnection);
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var screening = new ScreeningDto
                    {
                        Id = (int)reader["Id"],
                        MovieId = (int)reader["IdMovie"],
                        HallId = (int)reader["IdHall"],
                        DateOfScreening = (DateTime)reader["DateOfScreening"],
                        TimeOfScreening = (TimeSpan)reader["TimeOfScreening"]
                    };

                    screenings.Add(screening);
                }
            }
            _connection.SqlConnection.Close();
            return (screenings);
        }


        public void AddScreening(IScreening screening)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Screening OUTPUT Inserted.Id VALUES (@IdMovie, @IdHall, @DateOfScreening, @TimeOfScreening)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
            command.Parameters.AddWithValue("@IdHall", screening.HallId);
            command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
            command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);
            command.ExecuteScalar();
            _connection.SqlConnection.Close();
        }

        public void EditScreening(IScreening screening)
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
            _connection.SqlConnection.Close();
        }

        public void DeleteScreening(int id)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Screening WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public IScreening GetScreeningById(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var screening = new ScreeningDto
                    {
                        Id = (int)reader["Id"],
                        MovieId = (int)reader["IdMovie"],
                        HallId = (int)reader["IdHall"],
                        DateOfScreening = (DateTime)reader["DateOfScreening"],
                        TimeOfScreening = (TimeSpan)reader["TimeOfScreening"]
                    };
                    _connection.SqlConnection.Close();
                    return screening;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }

        public IHall GetHall(int idHall)
        {
            DatabaseHall databaseHall = new DatabaseHall(_connection);
            return databaseHall.GetHallById(idHall);
        }

        public IMovie GetMovie(int idMovie)
        {
            DatabaseMovie databaseMovie = new DatabaseMovie(_connection);
            return databaseMovie.GetMovieById(idMovie);
        }
    }
}
