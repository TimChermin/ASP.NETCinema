using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
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

        public List<ScreeningDto> GetScreenings()
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                var screenings = new List<ScreeningDto>();
                SqlCommand command = new SqlCommand("SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening", conn);

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
                return (screenings);
            }
        }


        public void AddScreening(ScreeningModel screening)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Screening VALUES (@IdMovie, @IdHall, @DateOfScreening, @TimeOfScreening)", conn);
                command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
                command.Parameters.AddWithValue("@IdHall", screening.HallId);
                command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
                command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);
                command.ExecuteScalar();
            }
        }

        public void EditScreening(ScreeningModel screening)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"UPDATE Screening SET IdMovie = @IdMovie, IdHall = @IdHall, DateOfScreening = @DateOfScreening, 
                TimeOfScreening = @TimeOfScreening WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", screening.Id);
                command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
                command.Parameters.AddWithValue("@IdHall", screening.HallId);
                command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
                command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteScreening(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("EXEC dbo.spScreening_DeleteScreening @screeningId", conn);
                command.Parameters.AddWithValue("@screeningId", id);
                command.ExecuteNonQuery();
            }
        }

        public ScreeningDto GetScreeningById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening WHERE Id = @Id", conn);
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
                        return screening;
                    }
                }
                return null;
            }
        }

        public HallDto GetHall(int idHall)
        {
            DatabaseHall databaseHall = new DatabaseHall(_connection);
            return databaseHall.GetHallById(idHall);
        }

        public MovieDto GetMovie(int idMovie)
        {
            DatabaseMovie databaseMovie = new DatabaseMovie(_connection);
            return databaseMovie.GetMovieById(idMovie);
        }

        public List<MovieDto> GetMovies()
        {
            DatabaseMovie databaseMovie = new DatabaseMovie(_connection);
            return databaseMovie.GetMovies(null);
        }

        public List<HallDto> GetHalls()
        {
            DatabaseHall databaseHall = new DatabaseHall(_connection);
            return databaseHall.GetHalls();
        }
    }
}
